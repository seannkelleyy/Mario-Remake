using System;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using Microsoft.Xna.Framework;

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
                ManageEntityCollisions(entity as IEnemy);
            }
        }

        private void ManageHeroCollisions(IHero hero)
        {
            HeroCollisionHandler heroHandler = new HeroCollisionHandler(hero);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                Logger.Instance.LogInformation($"checking between hero and {block}");
                if (hero.GetRectangle().Intersects(block.GetRectangle()))
                {
                    Logger.Instance.LogInformation($"intersection: {Rectangle.Intersect(hero.GetRectangle(), block.GetRectangle())}");

                    heroHandler.HeroBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (!enemy.ReportHealth())
                    return;
                if (hero.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    heroHandler.HeroEnemyCollision(enemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItems())
            {
                if (hero.GetRectangle().Intersects(item.GetRectangle()))
                {
                    heroHandler.HeroItemCollision(item);
                }
            }
        }

        private void ManageEntityCollisions(IEnemy enemy)
        {
            EnemyCollisionHandler enemyHandler = new EnemyCollisionHandler(enemy);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(enemy.GetPosition()))
            {
                if (enemy.GetRectangle().Intersects(block.GetRectangle()))
                {
                    enemyHandler.EnemyBlockCollision(block);

                }
            }

            foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemies())
            {
                if (!collidingEnemy.ReportHealth())
                    return;
                if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                {
                    enemyHandler.EnemyEnemyCollision(collidingEnemy);
                }
            }
        }
    }
}
