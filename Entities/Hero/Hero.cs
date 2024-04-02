using Mario.Collisions;
using Mario.Entities.Hero;
using Mario.Entities.Projectiles;
using Mario.Global;
using Mario.Entities.Abstract;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Mario.Global.CollisionVariables;
using static Mario.Physics.AbstractEntityPhysics;


namespace Mario.Entities.Character
{
    public class Hero : AbstractCollideable, IHero
    {
        private int lives;
        private bool isInvulnerable;
        private double invulnerableFrames;
        private const double invulnerableTime = 3.0;
        private bool isFlashing = false;
        private double flashIntervalTimer = 0.0;
        private const double flashDuration = 0.05;

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
            isInvunerable = false;
            iFrames = 0;
            this.lives = lives;
            this.position = position;
            physics = new HeroPhysics(this);
            currentState = new StandState(this);
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
                if (flashIntervalTimer > flashDuration)
                {
                    isFlashing = !isFlashing;
                    flashIntervalTimer = 0.0;
                }
                invulnerableFrames += gameTime.ElapsedGameTime.TotalSeconds;
                if (invulnerableFrames > invulnerableTime)
                {
                    isInvulnerable = false;
                    invulnerableFrames = 0.0;
                }
            }
        }
        public horizontalDirection getHorizontalDirection()
        {
            return physics.getHorizontalDirection();
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
            currentState.Jump();
        }

        public void SmallJump()
        {
            physics.SmallJump();
        }

        public void Crouch()
        {
            currentState.Crouch();
        }
        void IHero.Collect(IItem item)
        {
            if (item.GetType().Name.Equals("FireFlower") && currentHealth != health.FireMario)
            {
                bool wasSmall = currentHealth == health.Mario;
                currentHealth = health.FireMario;
                currentState.PowerUp(wasSmall);
            }
            else if (item.GetType().Name.Equals("Mushroom"))
            {
                if (((Mushroom)item).is1up())
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
                //adds to the coin count (needs to be implemented with scoreboard or coin tracker)
            }
            else if (item.GetType().Name.Equals("Star"))
            {
                //activate star mode (needs star mode to be implemented)
            }

        }
        public void TakeDamage()
        {
            if (!isInvulnerable)
            {
                if (currentHealth == health.Mario)
                {
                    Die();
                    return;
                }
                isInvunerable = true;
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
            currentState.Attack();
        }
        public void Die()
        {
            lives--;
            currentState.Die();
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
        public health ReportHealth()
        {
            return this.currentHealth;
        }
        public override Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)currentState.GetVector().X, (int)currentState.GetVector().Y);
        }

    }
}