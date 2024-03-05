using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private IHero mario;
        private List<IEntityBase> enemies;
        private List<IItem> items;
        private List<IBlock> blocks;
        private List<IEntityBase> projectiles;

        private static GameContentManager instance = new GameContentManager();

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance => instance;

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public void Load()
        {
            mario = GameObjectFactory.Instance.CreateEntity("Mario", new Vector2(100, 220)) as IHero;
            enemies = new List<IEntityBase>();
            items = new List<IItem>();
            blocks = new List<IBlock>();
            projectiles = new List<IEntityBase>();
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
            entities.AddRange(projectiles);
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
            else if (entity is IEntityBase)
            {
                projectiles.Add((IEntityBase)entity);
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
            else if(entity is IEntityBase)
            {
                projectiles.Remove((IEntityBase)entity);
            }

        }
    }
}

