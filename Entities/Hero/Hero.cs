using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Mario.Interfaces.Entities;
using Mario.Entities.Character.HeroStates;

namespace Mario.Entities.Character
{
    public class Hero : IHero
    {
        public HeroState currentState { get; set; }
        private SpriteBatch _spriteBatch;
        private Vector2 position;
        private int health = 1;

        public Hero(ContentManager content, SpriteBatch spriteBatch, Vector2 position)
        {
            _spriteBatch = spriteBatch;
            currentState = new StandingState(_spriteBatch);
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            // Additional game logic here (e.g., physics, collisions)
        }

        public void Draw()
        {
            currentState.Draw(_spriteBatch, position);
        }

        public void WalkLeft()
        {
            currentState = new LeftMovingState(_spriteBatch);
            position.X -= 2; // Move left
        }

        public void WalkRight()
        {
            currentState = new RightMovingState(_spriteBatch);
            position.X += 2; // Move right
        }

        public void Jump()
        {
            // Jump logic here
            currentState = new JumpState(_spriteBatch);
        }

        public void Crouch()
        {
            // Crouch logic here
            currentState = new CrouchState(_spriteBatch);
        }

        void IHero.Collect(IItem item)
        {
            currentState = new ClollectState(_spriteBatch);
        }

        void IHero.PowerUp()
        {
            currentState = new PowerUpState(_spriteBatch);
            if (health < 3)
            {
                health++;
            }
        }

        void IHero.TakeDamage()
        {
            currentState = new TakeDamageState(_spriteBatch);
            health--;
            if (health == 0)
            {
                Die();
            }
        }

        void IHero.Attack(Game game)
        {
            currentState = new AttackState(_spriteBatch);
        }


        public void Die()
        {
            currentState = new DeadState(_spriteBatch);
        }
    }
}