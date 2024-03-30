using Mario.Collisions;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Mario.Global.CollisionVariables;
using static Mario.Global.HeroVariables;


namespace Mario.Entities.Character
{
    public class Hero : AbstractCollideable, IHero
    {
        private HeroStateManager stateManager; // Strategy Pattern
        private int health;
        private int lives;
        private bool isInvunerable;
        private double iFrames;
        private const double invincibleTime = 3.0;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;
        private const double flashDuration = 0.05;

        public Hero(string startingPower, int lives, Vector2 position)
        {
            physics = new HeroPhysics(this);
            stateManager = new HeroStateManager(this);
            this.position = position;
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
            isInvunerable = false;
            iFrames = 0;
            this.lives = lives;
        }

        public override void Update(GameTime gameTime)
        {
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);
            CollisionManager.Instance.Run(this);
            // Check if Mario is invunerable 
            if (isInvunerable)
            {
                flashIntervalTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (flashIntervalTimer > flashDuration)
                {
                    isFlashing = !isFlashing;
                    flashIntervalTimer = 0.0;
                }
                iFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (iFrames > invincibleTime)
                {
                    isInvunerable = false;
                    iFrames = 0.0;
                }
            }

            physics.Update();
        }

        public new virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!isFlashing || !isInvunerable)
            {
                currentState.Draw(spriteBatch, position);
            }
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
                position.X += 2;
            }
            else if (collisions[CollisionDirection.Right])
            {
                position.X -= 2;
            }
        }

        public void StopVertical()
        {
            physics.StopVertical();
            if (collisions[CollisionDirection.Top])
            {
                position.Y += 5;
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
            if (health < 3)
            {
                health++;
            }
            stateManager.SetState(stateManager.GetStateType(), health);
        }

        public void TakeDamage()
        {
            if (!isInvunerable)
            {
                isInvunerable = true;
                health--;
                if (health == 0)
                {
                    Die();
                }
                else if (health == 1)
                {
                    position.Y += 16;
                }
                stateManager.SetState(stateManager.GetStateType(), health);
            }
        }

        public void Attack()
        {
            if (health == 3) // this will need changed if we add new power-ups.
            {
                GameContentManager.Instance.AddEntity(new Fireball(position));
                stateManager.SetState(HeroStateType.AttackingRight, health);
            }
        }

        public void Die()
        {
            lives--;
            stateManager.SetState(HeroStateType.Dead, health);
            LevelLoader.Instance.ChangeMarioLives($"../../../Levels/Sprint3.json", lives);

            // Check if the player still has lives. If so, reset the game but with one less life. Else, game over
            if (lives != 0)
            {
                GameStateManager.Instance.BeginReset();
            }
            else
            {
                lives = 10;
                GameStateManager.Instance.Restart();
            }
        }

        public int ReportHealth()
        {
            return health;
        }
    }
}