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
        private Dictionary<Keys, ICommand> Commands;

        // We will probably just instantiate these here for Spint 2 purposes,
        // but they will be gone after that.
        private IItem ItemSprite;
        private IBlock BlockSprite;
        // private IEnemy EnemySprite;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, ICommand>();
        }

        // NOTE: When we start saving the state for the character, we will pass in the GameContentManager
        // to assign the functions to call when keys are pressed.
        public void LoadCommands(MarioRemake game, ContentManager Content, SpriteBatch spriteBatch)
        {
            Commands.Add(Keys.Q, new QuitCommand(game));
            Commands.Add(Keys.R, new RestartCommand(game));

            //Commands.Add(Keys.W, );
            //Commands.Add(Keys.A, );
            //Commands.Add(Keys.S, );
            //Commands.Add(Keys.D, );
            //Commands.Add(Keys.E, );

            Commands.Add(Keys.I, new RelayCommand(new Action(ItemSprite.CycleItemNext)));
            Commands.Add(Keys.U, new RelayCommand(new Action(ItemSprite.CycleItemPrev)));
            Commands.Add(Keys.T, new RelayCommand(new Action(BlockSprite.CycleBlockNext)));
            Commands.Add(Keys.Y, new RelayCommand(new Action(BlockSprite.CycleBlockPrev)));

            // These will be added in enemy ticket.
            // Commands.Add(Keys.O, new RelayCommand(new Action(EnemySprite.CycleEnemyNext)));
            // Commands.Add(Keys.P, new RelayCommand(new Action(EnemySprite.CycleEnemyPrev)));
        }

        public void Add(Keys key, ICommand command)
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
                    Commands[key].Execute();
                }
            }
        }
    }
}
