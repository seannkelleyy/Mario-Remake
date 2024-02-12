using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Mario.Interfaces;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> Commands;

        public KeyboardController() {
            Commands = new Dictionary<Keys, ICommand>();
        }

        public void LoadCommands(MarioRemake game, ContentManager Content, SpriteBatch spriteBatch) {


            Commands.Add(Keys.Q, new QuitCommand(game));
            Commands.Add(Keys.R, new RestartCommand(game));

            //Jump
            // Commands.Add(Keys.W, );
            // Move left
            // Commands.Add(Keys.A, );
            // Crouch
            // Commands.Add(Keys.S, );
            // Move right
            // Commands.Add(Keys.D, );
            // Attack
            // Commands.Add(Keys.E, );

        }

        public void Add(Keys key, ICommand command)
        {
            Commands.Add(key, command); 
        }

        public void Update() {
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
