using Mario.Entities.Character.HeroStates;
using Mario.Entities.Hero;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private Vector2 position;
        private HeroPhysics physics;
        private int health = 1;
        // True is right, false is left
        private bool isFalling = false;

        public Hero(Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics();
            currentState = new StandingRightState();
        }

        public void Update(GameTime gameTime)
        {

            if (isFalling)
            {
                if (position.Y < 400)
                {
                    position.Y += physics.ApplyGravity();
                }
                else if (position.Y >= 400)
                {
                    isFalling = false;
                    if (physics.direction)
                    {
                        currentState = new StandingRightState();
                    }
                    else
                    {
                        currentState = new StandingLeftState();
                    }
                }
            }

            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void WalkLeft()
        {
            if (currentState is LeftMovingState)
            {
                position.X += physics.WalkLeft();
                return;
            }
            currentState = new LeftMovingState();
        }

        public void WalkRight()
        {
            if (currentState is RightMovingState)
            {
                position.X += physics.WalkRight();
                return;
            }
            currentState = new RightMovingState();
        }

        public void Jump()
        {
            Debug.WriteLine("Jumping");
            if (isFalling)
            {
                return;
            }
            if (currentState is JumpStateRight || currentState is JumpStateLeft)
            {
                return;
            }
            position.Y -= physics.Jump();
            if (physics.direction)
            {
                currentState = new JumpStateRight();
                position.Y -= physics.Jump();
                isFalling = true;
            }
            else
            {
                currentState = new JumpStateLeft();
                position.Y -= physics.Jump();
                isFalling = true;
            }
        }

        public void Crouch()
        {
            currentState = new CrouchState();
        }

        void IHero.Collect(IItem item)
        {
            currentState = new CollectState();
            if (health < 3)
            {
                health++;
            }
        }

        void IHero.TakeDamage()
        {
            health--;
            if (health == 0)
            {
                Die();
            }
        }

        void IHero.Attack()
        {
            // Make mario shoot fireball
        }


        public void Die()
        {
            currentState = new DeadState();
        }
    }
}