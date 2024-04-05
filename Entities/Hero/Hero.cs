using Mario.Collisions;
using Mario.Entities.Abstract;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Mario.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Mario.Global.GlobalVariables;


namespace Mario.Entities.Character
{
    public class Hero : AbstractCollideable, IHero
    {
        public HeroPhysics physics { get; }
        private int lives;
        private int startingLives;
        private bool isInvulnerable;
        private double invulnerabilityFrames;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;

        public new HeroState currentState { get; set; }
        public enum health { Mario, BigMario, FireMario };
        public health currentHealth = health.Mario;
        // True is right, false is left

        public Hero(string startingPower, int lives, Vector2 position)
        {
            switch (startingPower)
            {
                case "small":
                    currentHealth = health.Mario;
                    break;
                case "big":
                    currentHealth = health.BigMario;
                    break;
                case "fire":
                    currentHealth = health.FireMario;
                    break;
            }
            isInvulnerable = false;
            invulnerabilityFrames = 0;
            this.lives = lives;
            startingLives = lives;
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
        }

        public override void Update(GameTime gameTime)
        {
            ClearCollisions();

            currentState.Update(gameTime);
            CollisionManager.Instance.Run(this);

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
                if (flashIntervalTimer > EntitySettings.heroFlashDuration)
                {
                    isFlashing = !isFlashing;
                    flashIntervalTimer = 0.0;
                }
                invulnerabilityFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (invulnerabilityFrames > EntitySettings.heroInvulnerabilityTime)
                {
                    isInvulnerable = false;
                    invulnerabilityFrames = 0.0;
                }
            }

            physics.Update();
        }
        public horizontalDirection GetHorizontalDirection()
        {
            return physics.GetHorizontalDirection();
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
                position.X += horizontalBlockCollisionAdjustment;
            }
            else if (collisions[CollisionDirection.Right])
            {
                position.X -= horizontalBlockCollisionAdjustment;
            }
        }

        public void StopVertical()
        {
            physics.StopVertical();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += topBlockCollisionAdjustment;
            }
        }
        public void Jump()
        {
            if (currentHealth == health.BigMario || currentHealth == health.FireMario)
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.bigJump);
            }
            else
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.smallJump);
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
        void IHero.Collect(IItem item)
        {
            if (item.GetType().Name.Equals("FireFlower") && currentHealth != health.FireMario)
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.powerup);
                bool wasSmall = currentHealth == health.Mario;
                currentHealth = health.FireMario;
                currentState.PowerUp(wasSmall);
            }
            else if (item.GetType().Name.Equals("Mushroom"))
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.powerup);
                if (((Mushroom)item).Is1up())
                {
                    lives++;
                }
                else if (currentHealth == health.Mario)
                {
                    currentHealth = health.BigMario;
                    currentState.PowerUp(true);
                }
            }
            else if (item.GetType().Name.Equals("Coin"))
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.coin);
                //adds to the coin count (needs to be implemented with scoreboard or coin tracker)
            }
            else if (item.GetType().Name.Equals("Star"))
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
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.pipe);
                if (currentHealth == health.Mario)
                {
                    Die();
                    return;
                }
                isInvulnerable = true;
                if (currentHealth == health.BigMario)
                {
                    currentHealth = health.Mario;
                    position.Y += 16;
                }
                else
                {
                    currentHealth = health.BigMario;
                }
                currentState.TakeDamage();
            }
        }


        public void Attack()
        {
            if (currentHealth == health.FireMario)
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.fireball);
            }
            currentState.Attack();
        }
        public void Die()
        {
            lives--;
            currentState.Die();
            LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, lives);

            // Check if the player still has lives. If so, reset the game but with one less life. Else, game over
            if (lives != 0)
            {
                GameStateManager.Instance.BeginReset();
            }
            else
            {
                lives = startingLives;
                GameStateManager.Instance.Restart();
            }
        }
        public health ReportHealth()
        {
            return this.currentHealth;
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
        public HeroPhysics GetPhysics()
        {
            return physics;
        }
    }
}