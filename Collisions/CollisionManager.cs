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
            else if (entity is IItem)
            {
                ManageItemCollisions(entity as IItem);
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
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemiesInProximity(hero.GetPosition()))
            {
                if (hero.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    heroHandler.HeroEnemyCollision(enemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItemsInProximity(hero.GetPosition()))
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

            foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemiesInProximity(enemy.GetPosition()))
            {
                if (enemy != collidingEnemy && enemy.GetRectangle().Intersects(collidingEnemy.GetRectangle()))
                {
                    enemyHandler.EnemyEnemyCollision(collidingEnemy);
                }
            }
        }

        private void ManageItemCollisions(IItem item)
        {
            ItemCollisionHandler itemHandler = new ItemCollisionHandler(item);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(item.GetPosition()))
            {
                if (item.GetRectangle().Intersects(block.GetRectangle()))
                {
                    itemHandler.ItemBlockCollision(block);
                }
            }

            foreach (IItem collidingItem in GameContentManager.Instance.GetItemsInProximity(item.GetPosition())) 
            {
                if (item != collidingItem && item.GetRectangle().Intersects(collidingItem.GetRectangle()))
                {
                    itemHandler.ItemItemCollision(collidingItem);
                }
            }

        }

        private void ManageProjectileCollisions(IProjectile projectile)
        {
            ProjectileCollisionHandler projectileHandler = new ProjectileCollisionHandler(projectile);
            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(projectile.GetPosition()))
            {
                if (projectile.GetRectangle().Intersects(block.GetRectangle()))
                {
                    projectileHandler.ProjectileBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemiesInProximity(projectile.GetPosition()))
            {
                if (projectile.GetRectangle().Intersects(enemy.GetRectangle()))
                {
                    projectileHandler.ProjectileEnemyCollision(enemy);
                }
            }
        }
    }
}
