using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class MarioCollisionHandler
{
    public IHero mario { get; set; }
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

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new Action(mario.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new Action(mario.TakeDamage));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(() =>
        {
            mario.Jump();
            enemy.Stomp();
        }));
    }

    public void MarioEnemyCollision(IEnemy Enemy)
    {
        this.enemy = Enemy;
        //Figure out how to pass rectangle
        Vector2 marioPosition = mario.GetPosition();
        Rectangle MarioBox = new Rectangle((int)marioPosition.X, (int)marioPosition.Y, 30, 30);
        Vector2 enemyPosition = enemy.GetPosition();
        Rectangle EnemyBox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, 30, 30);

        CollisionDirection direction = CollisionDetector.DetectCollision(MarioBox, EnemyBox, mario.GetVelocity());
        if (collisionDictionary[typeof(IEnemy)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IEnemy)][direction].Invoke();
        }
    }

    public void MarioItemCollision(IItem Item)
    {
        this.item = Item;
        //Figure out how to pass rectangle
        Vector2 marioPosition = mario.GetPosition();
        Rectangle MarioBox = new Rectangle((int)marioPosition.X, (int)marioPosition.Y, 30, 30);
        Vector2 itemPosition = item.GetPosition();
        Rectangle ItemBox = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, 30, 30);

        CollisionDirection direction = CollisionDetector.DetectCollision(MarioBox, ItemBox, mario.GetVelocity());
        if (direction != CollisionDirection.None)
        {
            mario.Collect(item);
            //function that deletes item from the screen
        }
    }

    public void MarioBlockCollision(IBlock Block)
    {
        this.block = Block;
        //Figure out how to pass rectangle
        Vector2 marioPosition = mario.GetPosition();
        Rectangle MarioBox = new Rectangle((int)marioPosition.X, (int)marioPosition.Y, 30, 30);
        Vector2 blockPosition = block.GetPosition();
        Rectangle BlockBox = new Rectangle((int)blockPosition.X, (int)blockPosition.Y, 30, 30);


        CollisionDirection direction = CollisionDetector.DetectCollision(MarioBox, BlockBox, mario.GetVelocity());
        if (collisionDictionary[typeof(IBlock)].ContainsKey(direction))
        {
            collisionDictionary[typeof(IBlock)][direction].Invoke();
        }

    }
}
