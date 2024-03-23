using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Singletons
{
    public class GameRestarter
    {
        // This code follows the singleton pattern
        private static GameRestarter instance = new GameRestarter();
        public static GameRestarter Instance => instance;
         
        // Private constructor
        private GameRestarter() { }

        // Restarts the game
        public void Restart()
        {
            string currentApplication = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentApplication);
            Environment.Exit(0);
        }
    }
}
