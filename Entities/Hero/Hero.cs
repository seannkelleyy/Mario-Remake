using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Interfaces.Entities;
using Mario.Entities.Character.HeroStates;

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private SpriteBatch spriteBatch;
        private Vector2 position;
        private int health = 1;

        public Hero()
        {
            currentState = new StandingState(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            this.position = position;
            this.spriteBatch = spriteBatch;
            currentState.Draw(spriteBatch, position);
        }

        public void WalkLeft()
        {
            currentState = new LeftMovingState(spriteBatch);
            position.X -= 2; 
        }

        public void WalkRight()
        {
            currentState = new RightMovingState(spriteBatch);
            position.X += 2; 
        }

        public void Jump()
        {
            currentState = new JumpState(spriteBatch);
        }

        public void Crouch()
        {
            currentState = new CrouchState(spriteBatch);
        }

        void IHero.Collect(IItem item)
        {
            currentState = new ClollectState(spriteBatch);
            if (health < 3)
            {
                health++;
            }
        }

        void IHero.TakeDamage()
        {
            currentState = new TakeDamageState(spriteBatch);
            health--;
            if (health == 0)
            {
                Die();
            }
        }

        void IHero.Attack()
        {
            currentState = new AttackState(spriteBatch);
        }


        public void Die()
        {
            currentState = new DeadState(spriteBatch);
        }
    }
}