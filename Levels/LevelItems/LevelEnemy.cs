﻿using System.Collections.Generic;

namespace Mario.Levels.Level
{
    public class LevelEnemy
    {
        public string type { get; set; }
        public List<string> ai { get; set; }
        public int startingX { get; set; }
        public float startingY { get; set; }
        // true is right, false is left
        public bool isRight { get; set; }
    }
}
