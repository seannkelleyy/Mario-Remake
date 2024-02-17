using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Mario.Interfaces;
using Microsoft.Xna.Framework.Content;
using System;
using Mario.Interfaces.Entities;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, Action> Commands;

        // We will probably just instantiate these here for Spint 2 purposes,
        // but they will be gone after that.
        private IItem ItemSprite;
        private IBlock BlockSprite;
        private IHero HeroSprite;
        private IEnemyCycle EnemySprite;
        private Keys[] KeysPressed;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, Action>();
        }

        // NOTE: When we start saving the state for the character, we will pass in the GameContentManager
        // to assign the functions to call when keys are pressed.
        public void LoadCommands(MarioRemake game, ContentManager Content, SpriteBatch spriteBatch)
        {
            // System commands
            Commands.Add(Keys.Q, new Action(game.Exit));
            Commands.Add(Keys.R, new Action(game.Run));

            // Hero/Player Commands
            Commands.Add(Keys.W, new Action(HeroSprite.Jump));
            Commands.Add(Keys.A, new Action(HeroSprite.WalkLeft));
            Commands.Add(Keys.S, new Action(HeroSprite.Crouch));
            Commands.Add(Keys.D, new Action(HeroSprite.WalkRight));
            Commands.Add(Keys.E, new Action(HeroSprite.TakeDamage));

            // Non-moving entity Cycle Commands
            Commands.Add(Keys.I, new Action(ItemSprite.CycleItemNext));
            Commands.Add(Keys.U, new Action(ItemSprite.CycleItemPrev));
            Commands.Add(Keys.T, new Action(BlockSprite.CycleBlockNext));
            Commands.Add(Keys.Y, new Action(BlockSprite.CycleBlockPrev));

            // Moving entity Cycle Commands
            Commands.Add(Keys.O, new Action(EnemySprite.CycleEnemyNext));
            Commands.Add(Keys.P, new Action(EnemySprite.CycleEnemyPrev));
        }

        public void Add(Keys key, Action action)
        {
            Commands.Add(key, action);
        }

        public void Update()
        {
            KeysPressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in KeysPressed)
            {
                if (Commands.ContainsKey(key))
                {
                    Commands[key].Invoke();
                }
            }
        }
    }
}
