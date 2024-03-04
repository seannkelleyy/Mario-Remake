﻿using Mario.Interfaces;
using Mario.Interfaces.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private IHero mario;
        private List<IEnemy> enemies = new List<IEnemy>();
        private List<IItem> items = new List<IItem>();
        private List<IBlock> blocks = new List<IBlock>();

        private static GameContentManager instance = new GameContentManager();

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance => instance;

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public void Load()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string parentDir = Directory.GetParent(currentDir).FullName; // Go up 1 directory
            parentDir = Directory.GetParent(parentDir).FullName; // Go up 2 directories
            parentDir = Directory.GetParent(parentDir).FullName; // Go up 3 directories
            LevelLoader.Instance.LoadLevel($"{parentDir}/Levels/Sprint3.json");
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
            if (entity == null)
            {
                return;
            }
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
            Logger.Instance.LogInformation(entity.ToString() + " added to GameContentManager");
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

