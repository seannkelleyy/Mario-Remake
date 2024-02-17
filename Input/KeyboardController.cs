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
        private IItem item;
        private IBlock block;
        private IHero mario;
        private IEnemyCycle enemy;
        private Keys[] keysPressed;
        private delegate void NewGame(MarioRemake game);
        // private IEnemy EnemySprite;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, Action>();
        }

        // NOTE: When we start saving the state for the character, we will pass in the GameContentManager
        // to assign the functions to call when keys are pressed.
        public void LoadCommands(MarioRemake game, ContentManager Content, SpriteBatch spriteBatch)
        {
            Commands.Add(Keys.Q, new Action(game.Exit));
            Commands.Add(Keys.R, new Action(game.Run));

            Commands.Add(Keys.W, mario.Jump);
            Commands.Add(Keys.A, mario.WalkLeft);
            Commands.Add(Keys.S, mario.Crouch);
            Commands.Add(Keys.D, mario.WalkRight);
            Commands.Add(Keys.E, mario.Attack);

            Commands.Add(Keys.I, new Action(item.CycleItemNext));
            Commands.Add(Keys.U, new Action(item.CycleItemPrev));
            Commands.Add(Keys.T, new Action(block.CycleBlockNext));
            Commands.Add(Keys.Y, new Action(block.CycleBlockPrev));
            Commands.Add(Keys.O, new Action(enemy.CycleEnemyNext));
            Commands.Add(Keys.P, new Action(enemy.CycleEnemyPrev));
        }

        public void Add(Keys key, Action action)
        {
            Commands.Add(key, action);
        }

        public void Update()
        {
            keysPressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in keysPressed)
            {
                if (Commands.ContainsKey(key))
                {
                    Commands[key].Invoke();
                }
            }
        }
    }
}
