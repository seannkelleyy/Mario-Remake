using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Mario.Interfaces;
using GreenGame.Interfaces;
using Microsoft.Xna.Framework.Content;
using System;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, Action> Commands;

        // We will probably just instantiate these here for Spint 2 purposes,
        // but they will be gone after that.
        private IItem ItemSprite;
        private IBlock BlockSprite;
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
            Commands.Add(Keys.R, new Action());

            //Commands.Add(Keys.W, );
            //Commands.Add(Keys.A, );
            //Commands.Add(Keys.S, );
            //Commands.Add(Keys.D, );
            //Commands.Add(Keys.E, );

            Commands.Add(Keys.I, new Action(ItemSprite.CycleItemNext));
            Commands.Add(Keys.U, new Action(ItemSprite.CycleItemPrev));
            Commands.Add(Keys.T, new Action(BlockSprite.CycleBlockNext));
            Commands.Add(Keys.Y, new Action(BlockSprite.CycleBlockPrev));

            // These will be added in enemy ticket.
            // Commands.Add(Keys.O, new RelayCommand(new Action(EnemySprite.CycleEnemyNext)));
            // Commands.Add(Keys.P, new RelayCommand(new Action(EnemySprite.CycleEnemyPrev)));
        }

        public void Add(Keys key, Action command)
        {
            Commands.Add(key, command);
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (Keys key in Commands.Keys)
            {
                if (state.IsKeyDown(key))
                {
                    Commands[key].Invoke();
                }
            }
        }
    }
}
