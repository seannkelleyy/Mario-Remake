using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Levels.Level;
using Microsoft.Xna.Framework;
using System.IO;
using System.Text.Json;
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
            string jsonString = File.ReadAllText(levelName);
            Level level = JsonSerializer.Deserialize<Level>(jsonString)!;


            // Create the hero
            IHero hero = (IHero)GameObjectFactory.Instance.CreateEntity(level.hero.type, new Vector2(level.hero.startingX * 16, level.hero.startingY * 16));
            gameContentManager.AddEntity(hero);

            // Create the enemies
            foreach (LevelEnemy enemy in level.enemies)
            {
                IEnemy enemyObject = (IEnemy)GameObjectFactory.Instance.CreateEntity(enemy.type, new Vector2(enemy.startingX * 16, enemy.startingY * 16));
                gameContentManager.AddEntity(enemyObject);
            }

            // Create the block sections
            foreach (LevelBlockSection blockSection in level.block_sections)
            {
                for (int x = blockSection.startingX; x <= blockSection.endingX; x++)
                {
                    for (int y = blockSection.startingY; y <= blockSection.endingY; y++)
                    {
                        IBlock block = (IBlock)GameObjectFactory.Instance.CreateEntity(blockSection.type, new Vector2(x * 16, y * 16));
                        gameContentManager.AddEntity(block);
                    }
                }
            }

            // Create the individual blocks
            foreach (LevelBlock block in level.blocks)
            {
                IItem blockObject = (IItem)GameObjectFactory.Instance.CreateEntity(block.type, new Vector2(block.x * 16, block.y * 16));
                gameContentManager.AddEntity(blockObject);
            }
        }
    }
}
