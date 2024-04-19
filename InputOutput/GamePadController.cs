using Mario.Global;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
namespace Mario.Input
{
    public class GamePadController : IController
    {
        private Dictionary<Buttons, Action> Commands;
        private GamePadState previousGamePadState;
        float elapsedSeconds = 0;


        public GamePadController()
        {
            Commands = new Dictionary<Buttons, Action>();
        }

        public void LoadCommands(MarioRemake game)
        {
            Action[] actions = LoadActions(game);

            // System commands
            Commands.Add(Buttons.Start, actions[0]);
            Commands.Add(Buttons.Back, actions[1]);
            Commands.Add(Buttons.Y, actions[7]);

            // Movement commands
            Commands.Add(Buttons.LeftThumbstickUp, actions[2]);
            Commands.Add(Buttons.LeftThumbstickLeft, actions[3]);
            Commands.Add(Buttons.LeftThumbstickDown, actions[4]);
            Commands.Add(Buttons.LeftThumbstickRight, actions[5]);
            Commands.Add(Buttons.DPadLeft, actions[3]);
            Commands.Add(Buttons.DPadRight, actions[5]);
            Commands.Add(Buttons.DPadUp, actions[2]);
            Commands.Add(Buttons.DPadDown, actions[4]);
            Commands.Add(Buttons.A, actions[2]);

            // Mario commands
            Commands.Add(Buttons.X, actions[6]);
            Commands.Add(Buttons.RightShoulder, actions[6]);
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

            return actions;
        }

        public void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= GlobalVariables.InputControllerUpdateInterval)
            {
                elapsedSeconds = 0;
                // Handle controller input if the controller is connected
                GamePadState currentGamePadState = GamePad.GetState(PlayerIndex.One);

                if (currentGamePadState.IsConnected)
                {
                    List<Buttons> buttonsPressed = new List<Buttons>();
                    foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
                    {
                        if (currentGamePadState.IsButtonDown(button) && Commands.ContainsKey(button))
                        {
                            Commands[button].Invoke();
                        }
                    }

                    CheckForStopJump(currentGamePadState);
                    previousGamePadState = currentGamePadState; // Save the current state for the next frame
                }
            }
        }

        public void UpdatePause(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= GlobalVariables.InputControllerUpdateInterval)
            {
                elapsedSeconds = 0;
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Y))
                {
                    Commands[Buttons.Y].Invoke();
                }
            }
        }

        public void CheckForStopJump(GamePadState currentGamePadState)
        {
            // Check if the jump button was released
            if ((previousGamePadState.IsButtonDown(Buttons.LeftThumbstickUp) && currentGamePadState.IsButtonUp(Buttons.LeftThumbstickUp))
                || (previousGamePadState.IsButtonDown(Buttons.DPadUp) && currentGamePadState.IsButtonUp(Buttons.DPadUp))
                || (previousGamePadState.IsButtonDown(Buttons.X) && currentGamePadState.IsButtonUp(Buttons.X)))
            {
                GameContentManager.Instance.GetHero().StopJump();
            }
        }
    }
}
