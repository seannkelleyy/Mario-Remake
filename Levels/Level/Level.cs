using System.Collections.Generic;

namespace Mario.Levels.Level
{
    public class Level
    {
        int width { get; set; }
        int height { get; set; }
        LevelHero Hero { get; set; }
        List<LevelEnemy> enemies { get; set; }
        List<LevelBlockSection> block_sections { get; set; }
        List<LevelBlock> blocks { get; set; }
    }
}
