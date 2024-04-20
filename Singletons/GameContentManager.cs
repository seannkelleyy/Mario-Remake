using Mario.Global;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Interfaces.Entities.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private static GameContentManager instance = new GameContentManager();
        private Dictionary<Type, IList> entities = new Dictionary<Type, IList>
        {
            { typeof(IItem), new List<IItem>() },
            { typeof(IBlock), new List<IBlock>() },
            { typeof(IPipe), new List<IPipe>() },
            { typeof(IEnemy), new List<IEnemy>() },
            { typeof(IProjectile), new List<IProjectile>() },
            { typeof(IHero), new List<IHero>() }
        };

        public static GameContentManager Instance => instance;

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

        public List<IEnemy> GetEnemiesInProximity(Vector2 position)
        {

            List<IEnemy> enemies = new List<IEnemy>();
            foreach (IEnemy enemy in entities[typeof(IEnemy)])
            {
                if (enemy.GetPosition().X <= position.X + CollisionSettings.CollisionPixelRadius
                    && enemy.GetPosition().X >= position.X - CollisionSettings.CollisionPixelRadius && enemy.ReportIsAlive())
                {
                    if (enemy.ReportIsAlive())
                    {
                        enemies.Add(enemy);
                    }
                }
            }

            return enemies;
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

        public List<IItem> GetItemsInProximity(Vector2 position)
        {

            List<IItem> items = new List<IItem>();
            foreach (IItem item in entities[typeof(IItem)])
            {
                if (item.GetPosition().X <= position.X + CollisionSettings.CollisionPixelRadius
                    && item.GetPosition().X >= position.X - CollisionSettings.CollisionPixelRadius && item.isVisible)
                {
                    items.Add(item);
                }
            }

            return items;
        }

        public List<IProjectile> GetProjectiles()
        {
            List<IProjectile> allCollideables = new List<IProjectile>();
            foreach (IProjectile projetile in entities[typeof(IProjectile)])
            {
                allCollideables.Add(projetile);
            }
            return allCollideables;
        }

        // Gets all blocks within a certain position of mario that are collideable
        public List<IBlock> GetBlocksInProximity(Vector2 position)
        {

            List<IBlock> blocks = new List<IBlock>();
            foreach (IBlock block in entities[typeof(IBlock)])
            {
                if (block.GetPosition().X <= position.X + CollisionSettings.CollisionPixelRadius
                    && block.GetPosition().X >= position.X - CollisionSettings.CollisionPixelRadius && block.isCollideable)
                {
                    blocks.Add(block);
                }
            }

            return CombineBlocks(blocks);
        }

        // Gets all pipes 
        public List<IPipe> GetPipes(Vector2 position)
        {
            List<IPipe> allCollideables = new List<IPipe>();
            foreach (IPipe pipe in entities[typeof(IPipe)])
            {
                allCollideables.Add(pipe);
            }
            return allCollideables;
        }

        public List<IBlock> CombineBlocks(List<IBlock> blocks)
        {
            blocks.Sort((a, b) => a.GetPosition().Y.CompareTo(b.GetPosition().Y));

            List<IBlock> combinedBlocks = new List<IBlock>();
            List<IBlock> nonCombinableBlocks = blocks.Where(block => block.canBeCombined == false).ToList();

            blocks.RemoveAll(block => block.canBeCombined == false);

            for (int i = 0; i < blocks.Count;)
            {
                IBlock currentBlock = blocks[i];
                List<IBlock> sameLevelBlocks = new List<IBlock>();
                sameLevelBlocks.Add(currentBlock);
                int j = i;
                while (j + 1 < blocks.Count && (currentBlock.GetPosition().Y == blocks[j + 1].GetPosition().Y) && (blocks[j].GetPosition().X + GlobalVariables.BlockHeightWidth == blocks[j + 1].GetPosition().X))
                {
                    sameLevelBlocks.Add(blocks[j + 1]);
                    j++;
                }

                if (sameLevelBlocks.Count > 0)
                {
                    int combinedWidth = sameLevelBlocks.Sum(block => block.GetRectangle().Width);
                    int combinedHeight = sameLevelBlocks[0].GetRectangle().Height;

                    IBlock combinedBlock = new Block(currentBlock.GetPosition(), combinedWidth, combinedHeight, blocks[i].isBreakable);

                    combinedBlocks.Add(combinedBlock);
                }

                i += sameLevelBlocks.Count;
            }

            // Add the non-combinable blocks at the end
            combinedBlocks.AddRange(nonCombinableBlocks);

            return combinedBlocks;
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

        // Helper method to get the type of the entitys
        private Type GetEntityType(IEntityBase entity)
        {
            return entity is IHero ? typeof(IHero) :
                   entity is IEnemy ? typeof(IEnemy) :
                   entity is IItem ? typeof(IItem) :
                   entity is IBlock ? typeof(IBlock) :
                   entity is IPipe ? typeof(IPipe) :
                   entity is IProjectile ? typeof(IProjectile) : null;
        }
    }
}
