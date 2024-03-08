using Mario.Interfaces;
using Mario.Interfaces.Entities;

namespace Mario.Singletons
{
    public class CollisionManager
    {
        private static CollisionManager instance = new CollisionManager();
        public static CollisionManager Instance => instance;

        // private Dictionary<Type, Dictionary<Type, Dictionary<CollisionDirection, Action>>> collisionDictionary;

        private CollisionManager() { }


        public void HandleCollisions()
        {
            HandleHeroCollisions();
            HandleEnemyCollisions();
        }

        public void HandleHeroCollisions()
        {
            IHero hero = GameContentManager.Instance.GetHero();
            HeroCollisionHandler heroHandler = new HeroCollisionHandler(hero);

            foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(hero.GetPosition()))
            {
                if (block.GetRectangle().Intersects(hero.GetRectangle()))
                {
                    heroHandler.MarioBlockCollision(block);
                }
            }
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                if (enemy.GetRectangle().Intersects(hero.GetRectangle()))
                {
                    heroHandler.MarioEnemyCollision(enemy);
                }
            }
            foreach (IItem item in GameContentManager.Instance.GetItems())
            {
                if (item.GetRectangle().Intersects(hero.GetRectangle()))
                {
                    heroHandler.MarioItemCollision(item);
                }
            }
        }

        public void HandleEnemyCollisions()
        {
            foreach (IEnemy enemy in GameContentManager.Instance.GetEnemies())
            {
                EnemyCollisionHandler enemyHandler = new EnemyCollisionHandler(enemy);
                foreach (IBlock block in GameContentManager.Instance.GetBlocksInProximity(enemy.GetPosition()))
                {
                    if (block.GetRectangle().Intersects(enemy.GetRectangle()))
                    {
                        enemyHandler.EnemyBlockCollision(block);
                    }
                }
                foreach (IEnemy collidingEnemy in GameContentManager.Instance.GetEnemies())
                {
                    if (collidingEnemy.GetRectangle().Intersects(enemy.GetRectangle()))
                    {
                        enemyHandler.EnemyEnemyCollision(collidingEnemy);
                    }
                }
            }
        }
    }
}
