using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> Commands;
        private Keys[] KeysPressed;


        public KeyboardController(Dictionary<Keys, ICommand> commands) {
            Commands = commands;
        }
        public void Update() {
            KeysPressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in KeysPressed)
            {
                if (Commands.ContainsKey(key))
                {
                    Commands[key].Execute();
                }
            }
        }
    }
}
