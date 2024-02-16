using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Mario.Character.MarioStates;
using Microsoft.Xna.Framework.Graphics;
using Mario.Sprites;
using Mario.Interfaces.Entities;

namespace Mario.Character
{
    public class Hero : IHero
    {
        private SpriteBatch _spriteBatch;
        private int health = 1;
        private Vector2 position;
        public HeroState currentState { get; set; }
        private bool direction;

        public Hero(ContentManager content, SpriteBatch spriteBatch, Vector2 position)
        {
            _spriteBatch = spriteBatch;
            currentState = new StandingState(_spriteBatch); 
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            // Update Mario's state based on the current command executed
            // This could involve changing spriteStates and currentSprite based on the action
            currentState.Update(gameTime);
            // Additional game logic here (e.g., physics, collisions)
        }
        
        public void Draw()
        {
            currentState.Draw(_spriteBatch, position);
        }

        // Implementing IPlayer interface methods, these methods are called by commands
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
            if (this.health < 3){
                this.health++;
            }
        }

        void IHero.TakeDamage()
        {
            currentState = new TakeDamageState(_spriteBatch);
            this.health--;
            if (this.health == 0)
            {
                this.Die();
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