using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class CollisionHandler
{
    public CollisionHandler(IHero mario, List<IEntityBase> enemies, List<IItem> items, List<IBlock> blocks)
    {
        MarioCollision(mario, enemies, items, blocks);
        EnemyCollision(enemies, blocks);
    }

    public void MarioCollision(IHero mario, List<IEntityBase> enemies, List<IItem> items, List<IBlock> blocks)
    {
        MarioCollisionHandler heroHandler = new MarioCollisionHandler(mario);
        foreach (IEntityBase enemy in enemies)
        {
            heroHandler.MarioEnemyCollision(enemy);
        }
        foreach (IItem item in items)
        {
            heroHandler.MarioItemCollision(item);
        }
        foreach (IBlock block in blocks)
        {
            heroHandler.MarioBlockCollision(block);
        }
    }

    public void EnemyCollision(List<IEntityBase> enemies, List<IBlock> blocks)
    {
        foreach (IEntityBase enemy in enemies)
        {
            EnemyCollisionHandler enemyHandler = new EnemyCollisionHandler(enemy);
            foreach(IBlock block in blocks)
            {
                enemyHandler.EnemyBlockCollision(block);
            }
            foreach (IEntityBase enemy2 in enemies)
            {
                enemyHandler.EnemyEnemyCollision(enemy2);
            }
        }
        
    }
}