using Mario.Interfaces;
using Mario.Interfaces.Entities;
using System;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

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
            { typeof(IPipe), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() }
        };

        // Block stuff
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action(() =>
        {
            mainEnemy.SetCollisionState(CollisionDirection.Left, true);
            mainEnemy.ChangeDirection();
        }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action(() => {
            mainEnemy.SetCollisionState(CollisionDirection.Right, true);
            mainEnemy.ChangeDirection();
            }));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Bottom, true)));

        // Pipe stuff
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Left, new Action(() =>
        {
            mainEnemy.SetCollisionState(CollisionDirection.Left, true);
            mainEnemy.ChangeDirection();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Right, new Action(() => {
            mainEnemy.SetCollisionState(CollisionDirection.Right, true);
            mainEnemy.ChangeDirection();
        }));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Top, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Top, true)));
        collisionDictionary[typeof(IPipe)].Add(CollisionDirection.Bottom, new Action(() => mainEnemy.SetCollisionState(CollisionDirection.Bottom, true)));

        // Enemy stuff
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(HandleEnemyEnemyCollision));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(HandleEnemyEnemyCollision));
    }

    public void EnemyEnemyCollision(IEnemy enemy)
    {
        collidingEnemy = enemy;
        CollisionDirection direction = CollisionDetector.DetectCollision(mainEnemy.GetRectangle(), enemy.GetRectangle(), mainEnemy.GetVelocity());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void EnemyBlockCollision(IBlock block)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(mainEnemy.GetRectangle(), block.GetRectangle(), mainEnemy.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }

    public void EnemyPipeCollision(IPipe pipe)
    {
        CollisionDirection direction = CollisionDetector.DetectCollision(mainEnemy.GetRectangle(), pipe.GetRectangle(), mainEnemy.GetVelocity());
        if (collisionDictionary[typeof(IPipe)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IPipe)][direction].Invoke();
        }
    }

    public void HandleEnemyEnemyCollision()
    {
        if (mainEnemy is Koopa mainKoopa && mainKoopa.isShell)
        {
            if (collidingEnemy is not Koopa)
            {
                collidingEnemy.Flip();
                return;
            }
        }
        mainEnemy.ChangeDirection();
        collidingEnemy.ChangeDirection();
    }
}