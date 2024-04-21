using Mario.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using static Mario.Global.GlobalVariables;

namespace Mario.Singletons
{
    public class GameStateManager
    {
        // This code follows the singleton pattern
        private static GameStateManager instance = new GameStateManager();
        public static GameStateManager Instance => instance;
        public bool isPaused { get; private set; } = false;
        public bool isResetting { get; private set; } = false;
        public bool isWin { get; private set; } = false;
        public bool winScreen { get; set; } = false;
        public bool gameOver { get; private set;}
        public double resetTime { get; private set; } = 0.0;

        // Private constructor
        private GameStateManager() { }
        //
        public void Win()
        {
            Pause();
            if (!isWin)
            {
                MediaManager.Instance.PlayTheme(SongThemes.levelComplete, false);
            }
            isWin = !isWin;
            winScreen = true;
        }
        // Restarts the game
        public void Restart()
        {
            LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, EntitySettings.StartingHeroLives);
            string currentApplication = Process.GetCurrentProcess().MainModule.FileName;

            Process.Start(currentApplication);
            Environment.Exit(0);
        }

        // Pauses or unpauses the game
        public void Pause()
        {
            isPaused = !isPaused;
        }

        // Starts to reset the level after the player dies
        public void BeginReset(bool gameOver)
        {
            Pause();
            isResetting = true;
            this.gameOver = gameOver;
        }

        // Finishes resetting the level after the death animation plays
        public void EndReset(ref PlayerCamera camera)
        {
            if (!gameOver)
            {
                LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, GameContentManager.Instance.GetHero().GetStats().GetLives());
                SetResetTime(0.0);
                LevelLoader.Instance.UnloadLevel();
                LevelLoader.Instance.LoadLevel(GameSettingsLoader.LevelJsonFilePath);
                MediaManager.Instance.PlayDefaultTheme();
                isResetting = false;
                camera.ResetCamera();
                Pause();
            } else
            {
                Restart();
            }
            
        }

        public void SetResetTime(double time)
        {
            resetTime = time;
        }
    }
}
