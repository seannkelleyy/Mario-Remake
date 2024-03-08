using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class EnemyCollisionHandler
{
    public IEnemy enemy { get; set; }
    public IEnemy enemy2 { get; set; }
    public IBlock block { get; set; }

    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;

    public EnemyCollisionHandler(IEnemy Enemy)
    {
        this.enemy = Enemy;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action());

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(() => {
            enemy.ChangeDirection();
            enemy2.ChangeDirection();
        }));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(() => {
            enemy.ChangeDirection();
            enemy2.ChangeDirection();
        }));
    }

    public void EnemyEnemyCollision(IEnemy Enemy)
    {
        this.enemy2 = Enemy;
        //Figure out how to pass rectangle
        Vector2 enemy2Position = enemy2.GetPosition();
        Rectangle Enemy2Box = new Rectangle((int)enemy2Position.X, (int)enemy2Position.Y, 30, 30);
        Vector2 enemyPosition = enemy.GetPosition();
        Rectangle EnemyBox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, 30, 30);

        CollisionDirection direction = CollisionDetector.DetectCollision(EnemyBox, Enemy2Box);
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void EnemyBlockCollision(IBlock Block)
    {
       this. block = Block;
        //Figure out how to pass rectangle
        Vector2 enemyPosition = enemy.GetPosition();
        Rectangle EnemyBox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, 30, 30);
        Vector2 blockPosition = block.GetPosition();
        Rectangle BlockBox = new Rectangle((int)blockPosition.X, (int)blockPosition.Y, 30, 30);

        CollisionDirection direction = CollisionDetector.DetectCollision(EnemyBox, BlockBox);
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }
}