using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class MarioCollisionHandler 
{ 
    public IHero mario {  get; set; }
    public IEnemy enemy { get; set; }
    public IItem item { get; set; }
    public IBlock block { get; set; }

    private Dictionary<Type, Dictionary<CollisionDirection, Action>> collisionDictionary;


    public MarioCollisionHandler(IHero Mario)
    {
        this.mario = Mario;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>
        {
            { typeof(IBlock), new Dictionary<CollisionDirection, Action>() },
            { typeof(IEnemy), new Dictionary<CollisionDirection, Action>() },
            { typeof(IItem), new Dictionary<CollisionDirection, Action>() }
        };

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new Action());
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new Action());

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(mario.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(mario.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(() => {
            mario.Jump();
            enemy.Stomp();
            }));
    }

    public void MarioEnemyCollision(IEnemy Enemy)
    {
        this.enemy = Enemy;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void MarioItemCollision(IItem Item)
    {
        this.item = Item;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        if (direction != CollisionDirection.None)
        {
            mario.Collect(item);
        }
    }

    public void MarioBlockCollision(IBlock Block)
    {
        this.block = Block;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }

    }
}
 