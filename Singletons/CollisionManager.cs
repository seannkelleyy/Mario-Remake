using Mario.Interfaces;
using Mario.Interfaces.Entities;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class CollisionManager
    {
        private static CollisionManager instance = new CollisionManager();
        public static CollisionManager Instance => instance;
        IHero hero = GameContentManager.Instance.GetHero();

        private CollisionManager() { }

        public void Run()
        {
            DetectHeroCollisions();
            DetectEnemyCollisions();
        }

        private void DetectHeroCollisions()
        {
            List<IEnemy> entities = new List<IEnemy>();
            List<IItem> items = new List<IItem>();
            List<IBlock> blocks = new List<IBlock>();

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                Logger.Instance.LogInformation("Block in proximity");
                Logger.Instance.LogInformation("block: " + block.GetRectangle().ToString());
                Logger.Instance.LogInformation("hero: " + hero.GetRectangle().ToString());
                Logger.Instance.LogInformation("block intersects hero: " + hero.GetRectangle().Intersects(block.GetRectangle()));
                if (hero.GetRectangle().Intersects(block.GetRectangle()))
                {
                    Logger.Instance.LogInformation("Hero and Block collision detected");
                    blocks.Add(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                //Logger.Instance.LogInformation("Enemy in proximity");
                if (hero.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    Logger.Instance.LogInformation("Hero and enemy collision detected");
                    entities.Add(enemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItems())
            {
                if (hero.GetRectangle().Intersects(item.GetRectangle()))
                {
                    //Logger.Instance.LogInformation("Hero and item collision detected");
                    items.Add(item);
                }
            }
            CollisionHandler.Instance.HandleHeroCollisions(hero, entities, items, blocks);
        }

        private void DetectEnemyCollisions()
        {
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                List<IBlock> blocks = new List<IBlock>();
                foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(enemy.GetPosition()))
                {
                    if (enemy.GetRectangle().Intersects(block.GetRectangle()))
                    {
                        Logger.Instance.LogInformation("Enemy and block collision detected");
                        blocks.Add(block);
                    }
                }

                List<IEnemy> enemies = new List<IEnemy>();
                foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemies())
                {
                    if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                    {
                        Logger.Instance.LogInformation("Enemy and enemy collision detected");
                        enemies.Add(collidingEnemy);
                    }
                }
                CollisionHandler.Instance.HandleEnemyCollisions(enemies, blocks);
            }
        }
    }
}
