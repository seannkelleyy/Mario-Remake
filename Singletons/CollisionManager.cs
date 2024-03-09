using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class CollisionManager
    {
        private static CollisionManager instance = new CollisionManager();
        public static CollisionManager Instance => instance;

        private CollisionManager() { }

        //Fascade for the collision manager
        public void Run(IEntityBase entity)
        {
            if (entity is IHero)
            {
                DetectHeroCollisions(entity as IHero);
            }
            else if (entity is IEnemy)
            {
                DetectEnemyCollisions(entity as IEnemy);
            }
        }

        private void DetectHeroCollisions(IHero hero)
        {
            List<IEnemy> entities = new List<IEnemy>();
            List<IItem> items = new List<IItem>();
            List<IBlock> blocks = new List<IBlock>();

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                if (hero.GetRectangle().Intersects(block.GetRectangle()))
                {
                    Logger.Instance.LogInformation("Hero and Block collision detected");
                    blocks.Add(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (hero.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    entities.Add(enemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItems())
            {
                if (hero.GetRectangle().Intersects(item.GetRectangle()))
                {
                    items.Add(item);
                }
            }
            Logger.Instance.LogInformation($"Blocks colldied with:");
            foreach (IBlock block in blocks)
            {
                Logger.Instance.LogInformation(block.ToString());
            }
            CollisionHandler.Instance.HandleHeroCollisions(hero, entities, items, blocks);
        }

        private void DetectEnemyCollisions(IEnemy enemy)
        {
            List<IBlock> blocks = new List<IBlock>();
            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(enemy.GetPosition()))
            {
                if (enemy.GetRectangle().Intersects(block.GetRectangle()))
                {
                    blocks.Add(block);
                }
            }

            List<IEnemy> enemies = new List<IEnemy>();
            foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemies())
            {
                if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                {
                    enemies.Add(collidingEnemy);
                }
            }
            CollisionHandler.Instance.HandleEnemyCollisions(enemy, enemies, blocks);
        }
    }
}
