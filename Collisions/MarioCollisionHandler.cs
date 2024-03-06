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

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, Action>>();

        collisionDictionary.Add(typeof(IBlock), new Dictionary<CollisionDirection, Action>());
        collisionDictionary.Add(typeof(IEnemy), new Dictionary<CollisionDirection, Action>());
        collisionDictionary.Add(typeof(IItem), new Dictionary<CollisionDirection, Action>());

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new MarioBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new MarioBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new MarioBlockTop(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new MarioBlockBottom(this));

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new MarioEnemySide(this));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new MarioEnemySide(this));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(mario.Jump));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new Action(enemy.Stomp));
    }

    public void MarioEnemyCollision(IEnemy Enemy)
    {
        this.enemy = Enemy;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }

    public void MarioItemCollision(IItem Item)
    {
        this.item = Item;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }

    public void MarioBlockCollision(IBlock Block)
    {
        this.block = Block;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();

        if (direction != NoCollision)
        {
            //Call MarioItem();
        }
    }
}
 