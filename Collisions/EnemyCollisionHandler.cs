using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class EnemyCollisionHandler
{
    public IEnemy enemy { get; set; }
    public IEnemy enemy2 { get; set; }
    public IBlock block { get; set; }

    Dictionary<Type, Dictionary<CollisionDirection, /*delegate?*/> collisionDictionary;

    public EnemyCollisionHandler(IEnemy Enemy)
    {
        this.enemy = Enemy;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, /*delegate?*/>();

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new EnemyEnemySide(this));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new EnemyEnemySide(this));

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new EnemyBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new EnemyBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new EnemyBlockTop(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new EnemyBlockBottom(this));
    }

    public void EnemyEnemyCollision(IEnemy Enemy)
    {
        this.enemy2 = Enemy;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }

    public void EnemyBlockCollision(IBlock Block)
    {
       this. block = Block;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }
}