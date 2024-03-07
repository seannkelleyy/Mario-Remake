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

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>();

        collisionDictionary.Add(typeof(IBlock), new Dictionary<CollisionDirection, Action>());
        collisionDictionary.Add(typeof(IEnemy), new Dictionary<CollisionDirection, Action>());

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new EnemyBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new EnemyBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new EnemyBlockTop(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new EnemyBlockBottom(this));

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
        CollisionDirection direction = DetectCollision();
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void EnemyBlockCollision(IBlock Block)
    {
       this. block = Block;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }
    }
}