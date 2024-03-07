﻿using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
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
            { typeof(IHero), new List<IHero>() },
            { typeof(IEnemy), new List<IEnemy>() },
            { typeof(IItem), new List<IItem>() },
            { typeof(IBlock), new List<IBlock>() },
            { typeof(Fireball), new List<Fireball>() }
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

        public IHero GetHero()
        {
            return (IHero)entities[typeof(IHero)][0];
        }

        private Type GetEntityType(IEntityBase entity)
        {
            return entity is IHero ? typeof(IHero) :
                   entity is IEnemy ? typeof(IEnemy) :
                   entity is IItem ? typeof(IItem) :
                   entity is IBlock ? typeof(IBlock) : 
                   entity is Fireball ? typeof(Fireball):null;
        }

        public void AddEntity(IEntityBase entity)
        {
            if (entity == null)
            {
                return;
            }
            Type entityType = GetEntityType(entity);
            entities[entityType].Add(entity);
            Logger.Instance.LogInformation(entity.ToString() + " added to GameContentManager");
        }

        public void RemoveEntity(IEntityBase entity)
        {
            if (entity == null)
            {
                return;
            }
            Type entityType = GetEntityType(entity);
            entities[entityType].Remove(entity);
        }


    }
}
