using Mario.Levels.LevelItems;
using System.Collections.Generic;

namespace Mario.Levels.Level
{
    public class Level
    {
        public int width { get; set; }
        public int height { get; set; }
        public LevelHero hero { get; set; }
        public List<LevelEnemy> enemies { get; set; }
        public List<LevelBlockSection> block_sections { get; set; }
        public List<LevelBlock> blocks { get; set; }
    }
}
