using Mario.Input;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

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
        public const double maxResetTime = 4.0;

        // Private constructor
        private GameStateManager() { }

        // Restarts the game
        public void Restart()
        {
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
        public void EndReset()
        {
            SetResetTime(0.0);
            LevelLoader.Instance.UnloadLevel();
            LevelLoader.Instance.LoadLevel($"../../../Levels/Sprint3.json");
            isResetting = false;
            Pause();
        }

        public void SetResetTime(double time)
        {
            resetTime = time;
        }
    }
}
