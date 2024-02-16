using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Mario.Character.MarioStates;
using Microsoft.Xna.Framework.Graphics;
using Mario.Sprites;

namespace Mario.Character
{
    public class Mario : IHero
    {
        SpriteFactory _spriteFactory;
        protected SpriteBatch _spriteBatch;
        private int health;
        private IItem currentItem;
        private Vector2 position;
        private ISprite currentSprite;
        public MarioState currentState { get; set; }
        private bool direction;

        public Mario(ContentManager content, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {
            // Load all textures first
            _spriteFactory = spriteFactory;
            _spriteBatch = spriteBatch;
            currentSprite = _spriteFactory.CreateSprite("marioStandLeft");
            currentState = new StandingState(_spriteBatch, currentSprite); // Default state
            health = 1;
            this.currentItem = null;
        }

        public void Update(GameTime gameTime)
        {
            // Update Mario's state based on the current command executed
            // This could involve changing spriteStates and currentSprite based on the action
            currentState.Update(gameTime);
            // Additional game logic here (e.g., physics, collisions)
        }

        // Implementing IPlayer interface methods, these methods are called by commands
        public void WalkLeft()
        {
            currentSprite = _spriteFactory.CreateSprite("marioWalkLeft");
            currentState = new LeftMovingState(_spriteBatch, currentSprite);
            position.X -= 2; // Move left
        }

        public void WalkRight()
        {
            currentSprite = _spriteFactory.CreateSprite("marioWalkLeft");
            currentState = new RightMovingState(_spriteBatch, currentSprite);
            position.X += 2; // Move right
        }

        public void Jump()
        {
            // Jump logic here
            currentSprite = _spriteFactory.CreateSprite("marioJump");
            currentState = new JumpState(_spriteBatch, currentSprite);
        }

        public void Crouch()
        {
            // Crouch logic here
            currentSprite = _spriteFactory.CreateSprite("marioStandLeft");
            currentState = new CrouchState(_spriteBatch, currentSprite);
        }

        void IHero.Collect(IItem item)
        {
            currentSprite = _spriteFactory.CreateSprite("marioCrouch");
            currentState = new ClollectState(_spriteBatch, currentSprite);
            this.currentItem = item;
        }

        void IHero.PowerUp()
        {
            currentSprite = _spriteFactory.CreateSprite("marioPowerUp");
            currentState = new PowerUpState(_spriteBatch, currentSprite);
            if (this.health < 3){
                this.health++;
            }
        }

        void IHero.TakeDamage()
        {
            currentSprite = _spriteFactory.CreateSprite("marioTakeDamage");
            currentState = new TakeDamageState(_spriteBatch, currentSprite);
            this.health--;
            if (this.health == 0)
            {
                this.Die();
            }
        }

        void IHero.Attack(Game game)
        {
            currentSprite = _spriteFactory.CreateSprite("marioAttack");
            currentState = new AttackState(_spriteBatch, currentSprite);
        }

        
        public void Die()
        {
            // This sprite will need to be added to the spriteFactory
            currentSprite = _spriteFactory.CreateSprite("marioDie");
            currentState = new DeadState(_spriteBatch, currentSprite);
        }
    }
}