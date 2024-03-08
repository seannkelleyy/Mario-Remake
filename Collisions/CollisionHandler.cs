using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using System.Collections.Generic;

public class CollisionHandler
{
    public CollisionHandler(IHero mario, List<IEnemy> enemies, List<IItem> items, List<IBlock> blocks)
    {
        MarioCollision(mario, enemies, items, blocks);
        EnemyCollision(enemies, blocks);
    }

    public void MarioCollision(IHero mario, List<IEnemy> enemies, List<IItem> items, List<IBlock> blocks)
    {
        HeroCollisionHandler heroHandler = new HeroCollisionHandler(mario);
        foreach (IEntityBase enemy in enemies)
        {
            heroHandler.MarioEnemyCollision(enemy as IEnemy);
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

    public void EnemyCollision(List<IEnemy> enemies, List<IBlock> blocks)
    {
        foreach (IEnemy enemy in enemies)
        {
            EnemyCollisionHandler enemyHandler = new EnemyCollisionHandler(enemy);
            foreach (IBlock block in blocks)
            {
                enemyHandler.EnemyBlockCollision(block);
            }
            foreach (IEnemy collidingEnemy in enemies)
            {
                enemyHandler.EnemyEnemyCollision(collidingEnemy);
            }
        }
    }
}