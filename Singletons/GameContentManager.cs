using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private static GameContentManager instance = new GameContentManager();
        private Dictionary<Type, IList> entities = new Dictionary<Type, IList>
        {
            { typeof(IEnemy), new List<IEnemy>() },
            { typeof(IItem), new List<IItem>() },
            { typeof(IBlock), new List<IBlock>() },
            { typeof(Fireball), new List<Fireball>() },
            { typeof(IHero), new List<IHero>() }
        };

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance => instance;

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public List<IEntityBase> GetEntities()
        {
            List<IEntityBase> allEntities = new List<IEntityBase>();
            foreach (var entityList in entities.Values)
            {
                allEntities.AddRange((IEnumerable<IEntityBase>)entityList);
            }
            return allEntities;
        }

        public List<IEnemy> GetEnemies()
        {
            List<IEnemy> allCollideables = new List<IEnemy>();
            foreach (IEnemy enemy in entities[typeof(IEnemy)])
            {
                allCollideables.Add(enemy);
            }
            return allCollideables;
        }


        public List<IItem> GetItems()
        {
            List<IItem> allCollideables = new List<IItem>();
            foreach (IItem item in entities[typeof(IItem)])
            {
                allCollideables.Add(item);
            }
            return allCollideables;
        }


        // Gets all blocks within a certain position of mario that are collideable
        public List<IBlock> GetBlocksInProximity(Vector2 position)
        {
            List<IBlock> blocks = new List<IBlock>();
            foreach (IBlock block in entities[typeof(IBlock)])
            {
                if (block.GetPosition().X <= position.X + 16 && block.GetPosition().X >= position.X - 16 && block.isCollidable)
                {
                    blocks.Add(block);
                }
            }
            return blocks;
        }

        public IHero GetHero()
        {
            return (IHero)entities[typeof(IHero)][0];
        }

        public void AddEntity(IEntityBase entity)
        {
            if (entity == null)
            {
                return;
            }
            Type entityType = GetEntityType(entity);
            entities[entityType].Add(entity);
            //Logger.Instance.LogInformation(entity.ToString() + " added to GameContentManager");
        }

        public void RemoveEntity(IEntityBase entity)
        {
            if (entity == null)
            {
                return;
            }
            Type entityType = GetEntityType(entity);
            entities[entityType].Remove(entity);
            Logger.Instance.LogInformation(entity.ToString() + " removed from GameContentManager");
        }

        // Helper method to get the type of the entitys
        private Type GetEntityType(IEntityBase entity)
        {
            return entity is IHero ? typeof(IHero) :
                   entity is IEnemy ? typeof(IEnemy) :
                   entity is IItem ? typeof(IItem) :
                   entity is IBlock ? typeof(IBlock) : null;
        }
    }
}
