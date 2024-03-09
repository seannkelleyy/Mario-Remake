using Mario.Interfaces;
using Mario.Interfaces.Entities;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class EnemyCollisionHandler
{
    public IEnemy mainEnemy { get; set; }
    public IEnemy collidingEnemy { get; set; }

    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public EnemyCollisionHandler(IEnemy enemy)
    {
        mainEnemy = enemy;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Left, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Right, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Bottom, true)));

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(() =>
        {
            mainEnemy.ChangeDirection();
            collidingEnemy?.ChangeDirection();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(() =>
        {
            mainEnemy.ChangeDirection();
            collidingEnemy?.ChangeDirection();
        }));
    }

    public void EnemyEnemyCollision(IEnemy enemy)
    {
        collidingEnemy = enemy;
        CollisionDirection direction = CollisionDetector.DetectCollision(mainEnemy.GetVelocity(), mainEnemy.GetRectangle(), enemy.GetRectangle());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void EnemyBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(mainEnemy.GetVelocity(), mainEnemy.GetRectangle(), block.GetRectangle());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }
}