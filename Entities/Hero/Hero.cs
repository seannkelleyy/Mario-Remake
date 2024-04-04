using Mario.Collisions;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
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
        private HeroStateManager stateManager; // Strategy Pattern
        private int health;
        private int startingLives;
        private int lives;
        private bool isInvulnerable;
        private double invulnerabilityFrames;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;

        public Hero(string startingPower, int lives, Vector2 position)
        {
            physics = new HeroPhysics(this);
            stateManager = new HeroStateManager(this);
            this.position = position;
            startingLives = lives;
            this.lives = lives;

            switch (startingPower)
            {
                case "small":
                    health = 1;
                    break;
                case "big":
                    health = 2;
                    break;
                case "fire":
                    health = 3;
                    break;
            }
            stateManager.SetState(HeroStateType.StandingRight, health);
            isInvulnerable = false;
            invulnerabilityFrames = 0;
            this.lives = lives;
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

        public void WalkLeft()
        {
            if (stateManager.GetStateType() == HeroStateType.MovingLeft)
            {
                physics.WalkLeft();
                return;
            }
            physics.setHorizontalDirection(false);
            stateManager.SetState(HeroStateType.MovingLeft, health);
        }

        public void WalkRight()
        {
            if (stateManager.GetStateType() == HeroStateType.MovingRight)
            {
                physics.WalkRight();
                return;
            }
            physics.setHorizontalDirection(true);
            stateManager.SetState(HeroStateType.MovingRight, health);

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
            physics.Jump();

            if (physics.isRight)
            {
                stateManager.SetState(HeroStateType.JumpingRight, health);
            }
            else
            {
                stateManager.SetState(HeroStateType.JumpingLeft, health);
            }
        }

        public void StopJump()
        {
            physics.StopJump();
        }

        public void SmallJump()
        {
            physics.SmallJump();

            if (physics.isRight)
            {
                stateManager.SetState(HeroStateType.JumpingRight, health);
            }
            else
            {
                stateManager.SetState(HeroStateType.JumpingLeft, health);
            }
        }

        public void Crouch()
        {
            stateManager.SetState(HeroStateType.Crouching, health);
        }

        public void Collect(IItem item)
        {
            if (health < heroMaxHealth)
            {
                health++;
            }
            stateManager.SetState(stateManager.GetStateType(), health);
        }

        public void TakeDamage()
        {
            if (!isInvulnerable)
            {
                isInvulnerable = true;
                health--;
                if (health == 0)
                {
                    Die();
                }
                else if (health == 1) // mario becomes small and his height needs adjsuted.
                {
                    position.Y += blockHeightWidth;
                }
                stateManager.SetState(stateManager.GetStateType(), health);
            }
        }

        public void Attack()
        {
            if (health == heroMaxHealth) // this will need changed if we add new power-ups.
            {
                GameContentManager.Instance.AddEntity(new Fireball(position, physics.getHorizontalDirection()));
                stateManager.SetState(HeroStateType.AttackingRight, health);
            }
        }

        public void Die()
        {
            lives--;
            stateManager.SetState(HeroStateType.Dead, health);
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

        public int ReportHealth()
        {
            return health;
        }

        public int GetStartingLives()
        {
            return startingLives;
        }

        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}