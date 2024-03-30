using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Interfaces.Entities.Projectiles;
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
                ManageEnemyCollisions(entity as IEnemy);
            }
            else if (entity is IProjectile)
            {
                ManageProjectileCollisions(entity as IProjectile);
            }
        }

        private void ManageHeroCollisions(IHero hero)
        {
            HeroCollisionHandler heroHandler = new HeroCollisionHandler(hero);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                if (hero.GetRectangle().Intersects(block.GetRectangle()))
                {
                    heroHandler.HeroBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (!enemy.ReportIsAlive())
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

        private void ManageEnemyCollisions(IEnemy enemy)
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
                if (!collidingEnemy.ReportIsAlive())
                    return;
                if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                {
                    enemyHandler.EnemyEnemyCollision(collidingEnemy);
                }
            }
        }

        private void ManageProjectileCollisions(IProjectile projectile)
        {
            HeroCollisionHandler projectileHandler = new ProjectileCollisionHandler(projectile);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                if (projectile.GetRectangle().Intersects(block.GetRectangle()))
                {
                    projectileHandler.HeroBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (!enemy.ReportIsAlive())
                    return;
                if (projectile.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    projectileHandler.HeroEnemyCollision(enemy);
                }
            }
        }
    }
}
