using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private IHero mario;
        private List<IEntityBase> enemies;
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
            entities.AddRange(enemies);
            entities.AddRange(items);
            entities.AddRange(blocks);
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
                enemies.Add((IEnemy)entity);
            }
            else if (entity is IItem)
            {
                items.Add((IItem)entity);
            }
            else if (entity is IBlock)
            {
                blocks.Add((IBlock)entity);
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

