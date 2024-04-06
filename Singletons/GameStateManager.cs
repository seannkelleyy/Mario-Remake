using System;
using System.Diagnostics;

namespace Mario.Singletons
{
    public class GameStateManager
    {
        // This code follows the singleton pattern
        private static GameStateManager instance = new GameStateManager();
        public static GameStateManager Instance => instance;
        public bool isPaused { get; private set; } = false;
        public bool isResetting { get; private set; } = false;
        public double resetTime { get; private set; } = 0.0;

        // Private constructor
        private GameStateManager() { }

        // Restarts the game
        public void Restart()
        {
            LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, GameContentManager.Instance.GetHero().GetStartingLives());
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
        public void BeginReset()
        {
            Pause();
            isResetting = true;
        }

        // Finishes resetting the level after the death animation plays
        public void EndReset(PlayerCamera camera)
        {
            LevelLoader.Instance.ChangeMarioLives(GameSettingsLoader.LevelJsonFilePath, GameContentManager.Instance.GetHero().GetStartingLives());
            SetResetTime(0.0);
            LevelLoader.Instance.UnloadLevel();
            LevelLoader.Instance.LoadLevel(GameSettingsLoader.LevelJsonFilePath);
            isResetting = false;
            camera.ResetCamera();
            Pause();
        }

        public void SetResetTime(double time)
        {
            resetTime = time;
        }
    }
}
