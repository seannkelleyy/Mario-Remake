using Mario.Entities.Character;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private IHero mario;
        private IEnemy[] enemies;
        private IItem[] items;
        private IBlock[] blocks;
        private static GameContentManager instance = new GameContentManager();

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance
        {
            get
            {
                return instance;
            }
        }

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public void Load()
        {
            // Will call level loader 
            mario = new Hero(new Vector2(300, 100));
        }

        public IEntityBase[] GetEntities()
        {
            IEntityBase[] entities = new IEntityBase[1];
            entities[0] = mario;
            return entities;
        }

        public void AddEntity(IEntityBase entity)
        {
            if (entity is IHero)
            {
                mario = (IHero)entity;
            }
            else if (entity is IEnemy)
            {
                enemies.Append((IEnemy)entity);
            }
            else if (entity is IItem)
            {
                items.Append((IItem)entity);
            }
            else if (entity is IBlock)
            {
                blocks.Append((IBlock)entity);
            }
        }

        // Not sure how to procede here, since we don't have a way of 
        // knowing which entity to remove
        public void RemoveEntity(IEntityBase entity)
        {
            if (entity is IHero)
            {
                mario = null;
            }
            else if (entity is IEnemy)
            {
                // Remove enemy from list
            }
            else if (entity is IItem)
            {
                // Remove item from list
            }
            else if (entity is IBlock)
            {
                // Remove block from list
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
            foreach (IEnemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IItem item in items)
            {
                item.Draw(spriteBatch);
            }
            foreach (IBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
        }
    }
}

