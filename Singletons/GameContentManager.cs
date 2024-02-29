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
        }

        public List<IEntityBase> GetEntities()
        {
            List<IEntityBase> entities = new List<IEntityBase>();
            entities.Add(mario);
            entities.AddRange(enemies.Cast<IEntityBase>());
            entities.AddRange(items.Cast<IEntityBase>());
            entities.AddRange(blocks.Cast<IEntityBase>());
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

