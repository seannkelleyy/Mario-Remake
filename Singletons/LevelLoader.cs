using Mario.Interfaces.Entities;
using Mario.Levels.Level;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace Mario.Singletons
{
    public class LevelLoader
    {
        // Parse the JSON into a Level object
        string json = /* your JSON string */;
        Level level = JsonConvert.DeserializeObject<Level>("Sprint3.json");

        // Create the hero
        IHero hero = ObjectFactory.Create(level.hero.type, new Vector2(level.hero.starting_x * 16, level.hero.starting_y * 16));
        gameContentManager.Add(hero);

// Create the enemies
foreach (Enemy enemy in level.enemies)
{
    GameObject enemyObject = ObjectFactory.Create(enemy.type, new Vector2(enemy.starting_x, enemy.starting_y));
        gameContentManager.Add(enemyObject);
}

// Create the block sections
foreach (BlockSection blockSection in level.block_sections)
{
    for (int x = blockSection.starting_x; x <= blockSection.ending_x; x++)
    {
        for (int y = blockSection.starting_y; y <= blockSection.ending_y; y++)
        {
            GameObject block = ObjectFactory.Create(blockSection.type, new Vector2(x, y));
    gameContentManager.Add(block);
        }
    }
}

// Create the individual blocks
foreach (Block block in level.blocks)
{
    GameObject blockObject = ObjectFactory.Create(block.type, new Vector2(block.x, block.y));
    gameContentManager.Add(blockObject);
}

    }
}
