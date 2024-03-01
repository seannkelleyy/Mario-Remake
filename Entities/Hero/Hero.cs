using Mario.Entities.Character.HeroStates;
using Mario.Entities.Hero;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private Vector2 position;
        private HeroPhysics physics;
        private int health = 1;
        // True is right, false is left
        private bool direction = true;

        public Hero(Vector2 position)
        {
            this.position = position;
            physics = new HeroPhysics(direction);
            currentState = new StandingRightState();
        }

        public void Update(GameTime gameTime)
        {
            physics.Update(gameTime);
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
                position.X -= physics.velocity.X;
                return;
            }
            currentState = new LeftMovingState();
        }

        public void WalkRight()
        {
            if (currentState is RightMovingState)
            {
                position.X += physics.velocity.X;
                return;
            }
            currentState = new RightMovingState();
        }

        public void Jump()
        {
            if (currentState is JumpStateRight || currentState is JumpStateLeft)
            {
                position.Y -= physics.Jump();

                return;
            }
            position.Y -= 5;
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