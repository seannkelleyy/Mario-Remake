using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Levels.Level;
using Microsoft.Xna.Framework;

namespace Mario.Singletons
{
    public class LevelLoader
    {
        private GameContentManager gameContentManager;

        public LevelLoader(GameContentManager gameContentManager)
        {
            this.gameContentManager = gameContentManager;
        }

        public void LoadLevel(string levelName)
        {
            // Parse the JSON into a Level object
            string json = /* your JSON string */;
            Level level = JsonConvert.DeserializeObject<Level>("Sprint3.json");

            // Create the hero
            IHero hero = (IHero)GameObjectFactory.Instance.CreateEntity(level.hero.type, new Vector2(level.hero.startingX * 16, level.hero.startingY * 16));
            gameContentManager.AddEntity(hero);

            // Create the enemies
            foreach (LevelEnemy enemy in level.enemies)
            {
                IEnemy enemyObject = (IEnemy)GameObjectFactory.Instance.CreateEntity(enemy.type, new Vector2(enemy.startingX, enemy.startingY));
                gameContentManager.AddEntity(enemyObject);
            }

            // Create the block sections
            foreach (LevelBlockSection blockSection in level.block_sections)
            {
                for (int x = blockSection.startingX; x <= blockSection.endingX; x++)
                {
                    for (int y = blockSection.startingY; y <= blockSection.endingY; y++)
                    {
                        IBlock block = (IBlock)GameObjectFactory.Instance.CreateEntity(blockSection.type, new Vector2(x, y));
                        gameContentManager.AddEntity(block);
                    }
                }
            }

            // Create the individual blocks
            foreach (LevelBlock block in level.blocks)
            {
                IItem blockObject = (IItem)GameObjectFactory.Instance.CreateEntity(block.type, new Vector2(block.x, block.y));
                gameContentManager.AddEntity(blockObject);
            }
        }
    }
}
