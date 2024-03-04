using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private IHero mario;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<IBlock> blocks;

        private static GameContentManager instance = new GameContentManager();

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance => instance;

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public void Load()
        {
            // Will call level loader 
        }

        public List<IEntityBase> GetEntities()
        {
            List<IEntityBase> entities = new List<IEntityBase>
            {
                mario
            };
            entities.AddRange(enemies.Cast<IEntityBase>());
            entities.AddRange(items.Cast<IEntityBase>());
            entities.AddRange(blocks.Cast<IEntityBase>());
            return entities;
        }

        public IHero GetHero()
        {
            return mario; 
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

        public void RemoveEntity(IEntityBase entity)
        {
            if (entity is IHero)
            {
                mario = null;
            }
            else if (entity is IEnemy)
            {
                enemies.Remove((IEnemy)entity);
            }
            else if (entity is IItem)
            {
                items.Remove((IItem)entity);
            }
            else if (entity is IBlock)
            {
                blocks.Remove((IBlock)entity);
            }
        }
    }
}

