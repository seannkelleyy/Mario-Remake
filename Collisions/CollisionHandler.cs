using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using System.Collections.Generic;

public class CollisionHandler
{
    private static CollisionHandler instance = new CollisionHandler();
    public static CollisionHandler Instance => instance;

    private CollisionHandler() { }

    public void HandleHeroCollisions(IHero hero, List<IEnemy> enemies, List<IItem> items, List<IBlock> blocks)
    {
        HeroCollisionHandler heroHandler = new HeroCollisionHandler(hero);
        foreach (IEntityBase enemy in enemies)
        {
            heroHandler.HeroEnemyCollision(enemy as IEnemy);
        }
        foreach (IItem item in items)
        {
            heroHandler.HeroItemCollision(item);
        }
        foreach (IBlock block in blocks)
        {
            heroHandler.HeroBlockCollision(block);
        }
    }

    public void HandleEnemyCollisions(IEnemy enemy, List<IEnemy> enemies, List<IBlock> blocks)
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