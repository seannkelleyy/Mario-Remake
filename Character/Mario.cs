using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Mario.Character.MarioStates;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Character
{
    public class Mario : IHero
    {
        private int health;
        private IItem currentItem;
        private Vector2 position;
        private ISprite currentSprite;
        protected SpriteBatch SpriteBatch;
        public MarioState currentState { get; set; }
        private bool direction;

        public Mario(ContentManager content)
        {
            // Load all textures first
            SpriteFactory.Instance.LoadAllTextures(content);
            currentSprite = SpriteFactory.Instance.CreateSprite("marioStandLeft");
            currentState = new StandingState(SpriteBatch, currentSprite); // Default state
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
            currentSprite = SpriteFactory.Instance.CreateSprite("marioWalkLeft");
            currentState = new LeftMovingState(SpriteBatch, currentSprite);
            position.X -= 2; // Move left
        }

        public void WalkRight()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioWalkLeft");
            currentState = new RightMovingState(SpriteBatch, currentSprite);
            position.X += 2; // Move right
        }

        public void Jump()
        {
            // Jump logic here
            currentSprite = SpriteFactory.Instance.CreateSprite("marioJump");
            currentState = new JumpState(SpriteBatch, currentSprite);
        }

        public void Crouch()
        {
            // Crouch logic here
            currentSprite = SpriteFactory.Instance.CreateSprite("marioStandLeft");
            currentState = new CrouchState(SpriteBatch, currentSprite);
        }

        void IHero.Collect(IItem item)
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioCrouch");
            currentState = new ClollectState(SpriteBatch, currentSprite);
            this.currentItem = item;
        }

        void IHero.PowerUp()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioPowerUp");
            currentState = new PowerUpState(SpriteBatch, currentSprite);
            this.health++;
        }

        void IHero.TakeDamage()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioTakeDamage");
            currentState = new TakeDamageState(SpriteBatch, currentSprite);
            this.health--;
        }

        void IHero.Attack(Game game)
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioAttack");
            currentState = new AttackState(SpriteBatch, currentSprite);
        }

    }
}