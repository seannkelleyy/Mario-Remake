<<<<<<< Updated upstream
<<<<<<< Updated upstream
using Mario.Input;
using Mario.Sprites;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GreenGame.Interfaces;
using GreenGame.Character;
using GreenGame.Character.MarioStates;
using Microsoft.Xna.Framework.Content;

namespace Mario.Character
{
    public class Mario : IHero
    {
        private ISprite currentSprite;
        public IHeroState currentState;
        private bool direction;
        private KeyboardController keyboardController;

        public Mario(KeyboardController keyboardController,ContentManager content)
        {
            // Load all textures first
            SpriteFactory.Instance.LoadAllTextures(content);
            currentSprite = SpriteFactory.Instance.CreateSprite("marioStandLeft");
            currentState = new StandingState(this, direction, currentSprite); // Default state

            this.keyboardController = keyboardController;
        }

        public void Update(GameTime gameTime)
        {
            // Update Mario's state based on the current command executed
            // This could involve changing spriteStates and currentSprite based on the action
            keyboardController.Update(); // Process input and execute corresponding commands
            currentState.Update(gameTime);
            // Additional game logic here (e.g., physics, collisions)
        }

        // Implementing IPlayer interface methods, these methods are called by commands
        public void WalkLeft()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioWalkLeft");
            currentState = new StandingState(this, direction, currentSprite);
        }

        public void WalkRight()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioWalkLeft");
            currentState = new StandingState(this, direction, currentSprite);
        }

        public void Jump()
        {
            // Jump logic here
            currentSprite = SpriteFactory.Instance.CreateSprite("marioJump");
            currentState = new StandingState(this, direction, currentSprite);
        }

        public void Crouch()
        {
            // Crouch logic here
            currentSprite = SpriteFactory.Instance.CreateSprite("marioStandLeft");
            currentState = new StandingState(this, direction, currentSprite);
        }

        void IHero.Collect(IItem item)
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioCrouch");
            currentState = new StandingState(this, direction, currentSprite);
        }

        void IHero.PowerUp()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioPowerUp");
            currentState = new StandingState(this, direction, currentSprite);
        }

        void IHero.TakeDamage()
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioTakeDamage");
            currentState = new StandingState(this, direction, currentSprite);
        }

        void IHero.Attack(Game game)
        {
            currentSprite = SpriteFactory.Instance.CreateSprite("marioAttack");
            currentState = new StandingState(this, direction, currentSprite);
        }

    }
}