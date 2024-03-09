using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using System.Collections.Generic;

namespace Mario.Collisions
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
                ManageHeroCollisions(entity as IHero);
            }
            else if (entity is IEnemy)
            {
                ManageHeroCollisions(entity as IEnemy);
            }
        }

        private void ManageHeroCollisions(IHero hero)
        {
            HeroCollisionHandler heroHandler = new HeroCollisionHandler(hero);
            List<IBlock> blocks = new List<IBlock>(); //. testing only

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                if (hero.GetRectangle().Intersects(block.GetRectangle()))
                {
                    Logger.Instance.LogInformation("Hero and Block collision detected");
                    heroHandler.HeroBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (hero.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    heroHandler.HeroEnemyCollision(enemy as IEnemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItems())
            {
                if (hero.GetRectangle().Intersects(item.GetRectangle()))
                {
                    heroHandler.HeroItemCollision(item);
                }
            }
            Logger.Instance.LogInformation($"Blocks colldied with:");
            foreach (IBlock block in blocks)
            {
                Logger.Instance.LogInformation(block.ToString());
            }
        }

        private void ManageHeroCollisions(IEnemy enemy)
        {
            EnemyCollisionHandler enemyHandler = new EnemyCollisionHandler(enemy);

            List<IBlock> blocks = new List<IBlock>(); // testing only
            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(enemy.GetPosition()))
            {
                if (enemy.GetRectangle().Intersects(block.GetRectangle()))
                {
                    enemyHandler.EnemyBlockCollision(block);

                }
            }

            List<IEnemy> enemies = new List<IEnemy>();
            foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemies())
            {
                if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                {
                    enemyHandler.EnemyEnemyCollision(collidingEnemy);
                }
            }
        }
    }
}
