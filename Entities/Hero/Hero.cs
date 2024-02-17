using Mario.Entities.Character.HeroStates;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private int health = 1;
        // True is right, false is left
        private Boolean direction = true;

        public Hero(Vector2 position)
        {
            this.position = position;
            currentState = new StandingRightState();
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            currentState.Draw(spriteBatch, position);
        }

        public void WalkLeft()
        {
            currentState = new LeftMovingState();
            position.X -= 2;
        }

        public void WalkRight()
        {
            currentState = new RightMovingState();
            position.X += 2;
        }

        public void Jump()
        {
            if (currentState is JumpStateRight || currentState is JumpStateLeft)
            {
                return;
            }
            position.Y += 5;

            if (direction)
            {
                currentState = new JumpStateRight();
            }
            else
            {
                currentState = new JumpStateLeft();
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