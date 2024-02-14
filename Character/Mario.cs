<<<<<<< Updated upstream
<<<<<<< Updated upstream
﻿using Mario.Input;
using Mario.Sprites;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GreenGame.Interfaces;
using GreenGame.Interfaces.Entities;

namespace Mario.Character
{
    public class Mario : IHero
    {
        public IHeroState state;
        private bool direction;
        //private Dictionary<string, Texture2D> sprites;
        //private Vector2 position;
        //private Texture2D currentSprite;
        //private KeyboardController keyboardController;

        public Mario(Dictionary<string, Texture2D> sprites, KeyboardController keyboardController)
        {
            state = new MarioStandingState(this, direction); // Default state
        }

        public void Update(GameTime gameTime)
        {
            // Update Mario's state based on the current command executed
            // This could involve changing spriteStates and currentSprite based on the action
            // keyboardController.Update(); // Process input and execute corresponding commands

            // Additional game logic here (e.g., physics, collisions)
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentSprite, position, Color.White);
        }

        // Implementing IPlayer interface methods, these methods are called by commands
        public void WalkLeft()
        {
            position.X -= 2; // Move left
            state = SpriteStates.WalkingLeft;
            currentSprite = sprites["WalkingLeft"];
        }

        public void WalkRight()
        {
            position.X += 2; // Move right
            state = SpriteStates.WalkingRight;
            currentSprite = sprites["WalkingRight"];
        }

        public void Jump()
        {
            // Jump logic here
            state = SpriteStates.Jumping;
            currentSprite = sprites["Jumping"];
        }

        public void Crouch()
        {
            // Crouch logic here
            state = SpriteStates.Crouching;
            currentSprite = sprites["Crouching"];
        }

        void IHero.Collect(IItem item)
        {
            throw new System.NotImplementedException();
        }

        void IHero.PowerUp()
        {
            throw new System.NotImplementedException();
        }

        void IHero.TakeDamage()
        {
            throw new System.NotImplementedException();
        }

        void IHero.Attack(Game game)
        {
            throw new System.NotImplementedException();
        }

        void ISprite.Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            throw new System.NotImplementedException();
        }
    }
}