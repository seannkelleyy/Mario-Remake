using Mario.Global;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, Action> Commands;
        private KeyboardState previousKeyboardState;
        private Keys[] keysPressed;
        float elapsedSeconds = 0;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, Action>();
        }

        public void LoadCommands(MarioRemake game)
        {
            Action[] actions = LoadActions(game);

            // System commands
            Commands.Add(Keys.Q, actions[0]);
            Commands.Add(Keys.R, actions[1]);
            Commands.Add(Keys.Escape, actions[7]);
            Commands.Add(Keys.P, actions[7]);
            Commands.Add(Keys.F, actions[8]);

            // WASD commands
            Commands.Add(Keys.W, actions[2]);
            Commands.Add(Keys.A, actions[3]);
            Commands.Add(Keys.S, actions[4]);
            Commands.Add(Keys.D, actions[5]);
            Commands.Add(Keys.E, actions[6]);
            Commands.Add(Keys.LeftShift, actions[6]);

            // Arrow commands
            Commands.Add(Keys.Left, actions[3]);
            Commands.Add(Keys.Right, actions[5]);
            Commands.Add(Keys.Up, actions[2]);
            Commands.Add(Keys.Down, actions[4]);
            Commands.Add(Keys.Space, actions[2]);
            Commands.Add(Keys.RightControl, actions[6]);
        }

        private Action[] LoadActions(MarioRemake game)
        {
            Action[] actions = new Action[9];
            actions[0] = new Action(() =>
            {
                LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, GameContentManager.Instance.GetHero().GetStartingLives());
                game.Exit();
            });
            actions[1] = new Action(GameStateManager.Instance.Restart);
            actions[2] = new Action(() =>
            {
                // This allows for mario to move up and to the left or right
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    GameContentManager.Instance.GetHero().Jump();
                    GameContentManager.Instance.GetHero().WalkLeft();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    GameContentManager.Instance.GetHero().Jump();
                    GameContentManager.Instance.GetHero().WalkRight();
                }
                else
                {
                    GameContentManager.Instance.GetHero().Jump();
                }
            });
            actions[3] = new Action(GameContentManager.Instance.GetHero().WalkLeft);
            actions[4] = new Action(GameContentManager.Instance.GetHero().Crouch);
            actions[5] = new Action(GameContentManager.Instance.GetHero().WalkRight);
            actions[6] = new Action(GameContentManager.Instance.GetHero().Attack);
            actions[7] = new Action(() =>
            {
                GameStateManager.Instance.Pause();
                if (GameStateManager.Instance.isPaused)
                {
                    MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.pause);
                    MediaPlayer.Pause();
                }
                else
                {
                    MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.pause);
                    MediaPlayer.Resume();
                }
            });
            actions[8] = new Action(game.ChangeFullScreenMode);
            return actions;
        }

        public void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= GlobalVariables.InputControllerUpdateInterval)
            {
                elapsedSeconds = 0;
                KeyboardState currentKeyboardState = Keyboard.GetState();
                keysPressed = currentKeyboardState.GetPressedKeys();
                foreach (Keys key in keysPressed)
                {
                    if (Commands.ContainsKey(key))
                    {
                        Commands[key].Invoke();
                    }
                }

                CheckForStopJump(currentKeyboardState);

                previousKeyboardState = currentKeyboardState; // Save the current state for the next frame
            }
        }

        public void UpdatePause(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= GlobalVariables.InputControllerUpdateInterval)
            {
                elapsedSeconds = 0;
                keysPressed = Keyboard.GetState().GetPressedKeys();
                if (keysPressed.Contains(Keys.P) || keysPressed.Contains(Keys.Escape))
                {
                    Commands[Keys.P].Invoke();
                }
            }
        }

        public void CheckForStopJump(KeyboardState currentKeyboardState)
        {
            // Check if the jump key was released
            if ((previousKeyboardState.IsKeyDown(Keys.W) && currentKeyboardState.IsKeyUp(Keys.W))
                || (previousKeyboardState.IsKeyDown(Keys.Space) && currentKeyboardState.IsKeyUp(Keys.Space))
                || (previousKeyboardState.IsKeyDown(Keys.Up) && currentKeyboardState.IsKeyUp(Keys.Up)))
            {
                GameContentManager.Instance.GetHero().StopJump();
            }
        }
    }
}
