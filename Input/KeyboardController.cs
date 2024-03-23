using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, Action> Commands;

        // We will probably just instantiate these here for Spint 2 purposes,
        // but they will be gone after that.
        private IHero mario;
        private Keys[] keysPressed;
        float updateInterval = 0.1f;
        float elapsedSeconds = 0;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, Action>();
        }

        // NOTE: When we start saving the state for the character, we will pass in the GameContentManager
        // to assign the functions to call when keys are pressed.
        public void LoadCommands(MarioRemake game, IHero hero)
        {
            mario = hero;

            Action[] actions = LoadActions(game);

            // System commands
            Commands.Add(Keys.Q, actions[0]);
            Commands.Add(Keys.R, actions[1]);
            Commands.Add(Keys.Escape, actions[7]);
            Commands.Add(Keys.P, actions[7]);

            // WASD commands
            Commands.Add(Keys.W, actions[2]);
            Commands.Add(Keys.A, actions[3]);
            Commands.Add(Keys.S, actions[4]);
            Commands.Add(Keys.D, actions[5]);
            Commands.Add(Keys.E, actions[6]);

            // Arrow commands
            Commands.Add(Keys.Left, actions[3]);
            Commands.Add(Keys.Right, actions[5]);
            Commands.Add(Keys.Up, actions[2]);
            Commands.Add(Keys.Down, actions[4]);
            Commands.Add(Keys.Space, actions[2]);
            Commands.Add(Keys.RightControl, actions[6]);
        }

        public void Add(Keys key, Action action)
        {
            Commands.Add(key, action);
        }

        private Action[] LoadActions(MarioRemake game)
        {
            Action[] actions = new Action[8];
            actions[0] = new Action(game.Exit);
            actions[1] = new Action(game.Restart);
            actions[2] = new Action(() =>
            {
                // This allows for mario to move up and to the left or right
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    mario.Jump();
                    mario.WalkLeft();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    mario.Jump();
                    mario.WalkRight();
                }
                else
                {
                    mario.Jump();
                }
            });
            actions[3] = new Action(mario.WalkLeft);
            actions[4] = new Action(mario.Crouch);
            actions[5] = new Action(mario.WalkRight);
            actions[6] = new Action(mario.Attack);
            actions[7] = new Action(game.Pause);
            return actions;
        }

        public void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= updateInterval)
            {
                elapsedSeconds = 0;
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
}
