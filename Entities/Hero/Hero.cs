using Mario.Collisions;
using Mario.Entities.Abstract;
using Mario.Entities.Hero;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Mario.Global.GlobalVariables;


namespace Mario.Entities.Character
{
    public class Hero : AbstractCollideable, IHero
    {
        public HeroPhysics physics { get; }
        public HeroStatTracker stats { get; }
        private int startingLives;
        private bool isInvulnerable = false;
        private double invulnerabilityFrames = 0;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;
        public new HeroState currentState { get; set; }
        public HeroHealth currentHealth = HeroHealth.Mario;

        public Hero(string startingPower, Vector2 position, HeroStatTracker stats)
        {
            switch (startingPower)
            {
                case "small":
                    currentHealth = HeroHealth.Mario;
                    break;
                case "big":
                    currentHealth = HeroHealth.BigMario;
                    break;
                case "fire":
                    currentHealth = HeroHealth.FireMario;
                    break;
            }
            this.position = position;
            this.stats = stats;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
            startingLives = stats.GetLives();
        }

        public override void Update(GameTime gameTime)
        {
            ClearCollisions();

            currentState.Update(gameTime);

            stats.Update(gameTime);

            CollisionManager.Instance.Run(this);

            if (position.X - GetVelocity().X <= CameraLeftEdge)
            {
                StopHorizontal();
                SetCollisionState(CollisionDirection.Left, true);
                position.X += HorizontalBlockCollisionAdjustment;
            }

            HandleInvulnerability(gameTime);

            physics.Update();
        }

        public new virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!isFlashing || !isInvulnerable)
            {
                currentState.Draw(spriteBatch, position);
            }
        }

        private void HandleInvulnerability(GameTime gameTime)
        {
            if (isInvulnerable)
            {
                flashIntervalTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (flashIntervalTimer > EntitySettings.HeroFlashDuration)
                {
                    isFlashing = !isFlashing;
                    flashIntervalTimer = 0.0;
                }
                invulnerabilityFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (invulnerabilityFrames > EntitySettings.HeroInvulnerabilityTime)
                {
                    isInvulnerable = false;
                    invulnerabilityFrames = 0.0;
                }
            }

            physics.Update();
        }
        public void WalkLeft()
        {
            currentState.WalkLeft();
        }
        public void WalkRight()
        {
            currentState.WalkRight();
        }
        public void Stand()
        {
            currentState.Stand();
        }

        public void StopHorizontal()
        {
            physics.StopHorizontal();
            if (collisions[CollisionDirection.Left])
            {
                position.X += HorizontalBlockCollisionAdjustment;
            }
            else if (collisions[CollisionDirection.Right])
            {
                position.X -= HorizontalBlockCollisionAdjustment;
            }
        }

        public void StopVertical()
        {
            physics.StopVertical();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += TopBlockCollisionAdjustment;
            }
        }
        public void Jump()
        {
            if (currentHealth == HeroHealth.BigMario || currentHealth == HeroHealth.FireMario)
            {
                MediaManager.Instance.PlayEffect(EffectNames.bigJump);
            }
            else
            {
                MediaManager.Instance.PlayEffect(EffectNames.smallJump);
            }
            currentState.Jump();
        }

        public void SmallJump()
        {
            physics.SmallJump();
        }
        public void StopJump()
        {
            physics.StopJump();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }
        public void Collect(IItem item)
        {
            if (item is FireFlower)
            {
                if (currentHealth != HeroHealth.FireMario)
                {
                    MediaManager.Instance.PlayEffect(EffectNames.powerup);
                    bool wasSmall = currentHealth == HeroHealth.Mario;
                    currentHealth = HeroHealth.FireMario;
                    currentState.PowerUp(wasSmall);
                }
            }
            else if (item is Mushroom)
            {
                if (((Mushroom)item).IsOneUp())
                {
                    MediaManager.Instance.PlayEffect(EffectNames.oneUp);
                    stats.AddLives(1);
                    return;
                }
                else if (currentHealth == HeroHealth.Mario)
                {
                    currentHealth = HeroHealth.BigMario;
                    position.Y += BlockHeightWidth;
                    currentState.PowerUp(true);
                }
                MediaManager.Instance.PlayEffect(EffectNames.powerup);
            }
            else if (item is Coin)
            {
                stats.AddCoins(1);
                if (stats.GetCoins() % 100 == 0)
                {
                    stats.AddLives(1);
                    stats.SetCoins(0);
                }
                MediaManager.Instance.PlayEffect(EffectNames.coin);
            }
            else if (item is Star)
            {
                //add sound theme changes here
                //activate star mode (needs star mode to be implemented)
            }

        }
        public void TakeDamage()
        {
            if (!isInvulnerable)
            {
                // Pipe is the same sfx as taking damage.
                MediaManager.Instance.PlayEffect(EffectNames.pipe);
                if (currentHealth == HeroHealth.Mario)
                {
                    Die();
                    return;
                }
                isInvulnerable = true;
                if (currentHealth == HeroHealth.BigMario)
                {
                    currentHealth = HeroHealth.Mario;
                    position.Y += BlockHeightWidth;
                }
                else
                {
                    currentHealth = HeroHealth.BigMario;
                }
                currentState.TakeDamage();
            }
        }

        public void Attack()
        {
            if (currentHealth == HeroHealth.FireMario)
            {
                MediaManager.Instance.PlayEffect(EffectNames.fireball);
            }
            currentState.Attack();
        }
        public void Die()
        {
            stats.AddLives(-1);
            currentState.Die();
            LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, stats.GetLives());

            // Check if the player still has lives. If so, reset the game but with one less life. Else, game over
            if (stats.GetLives() != 0)
            {
                GameStateManager.Instance.BeginReset();
            }
            else
            {
                stats.SetLives(startingLives);
                GameStateManager.Instance.Restart();
            }
        }
        public HeroHealth ReportHealth()
        {
            return currentHealth;
        }
        public override Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)currentState.GetVector().X, (int)currentState.GetVector().Y);
        }

        public int GetStartingLives()
        {
            return startingLives;
        }

        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
        public HorizontalDirection GetHorizontalDirection()
        {
            return physics.GetHorizontalDirection();
        }
        public HeroPhysics GetPhysics()
        {
            return physics;
        }
    }
}