using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class MarioCollisionHandler 
{ 
    public IHero mario {  get; set; }
    public IEntityBase enemy { get; set; }
    public IItem item { get; set; }
    public IBlock block { get; set; }

    Dictionary<Type, Dictionary<CollisionDirection, /*delegate?*/> collisionDictionary;


    public MarioCollisionHandler(IHero Mario)
    {
        this.mario = Mario;

        collisionDictionary = new Dictionary<Type, Dictionary<CollisionDirection, /*delegate?*/>();

        collisionDictionary.Add(typeof(IBlock), new Dictionary<CollisionDirection, /*delegate?*/>());
        collisionDictionary.Add(typeof(IEnemy), new Dictionary<CollisionDirection, /*delegate?*/>());
        collisionDictionary.Add(typeof(IItem), new Dictionary<CollisionDirection, /*delegate?*/>());

        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Left, new MarioBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Right, new MarioBlockSide(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Top, new MarioBlockTop(this));
        collisionDictionary[typeof(IBlock)].Add(CollisionDirection.Bottom, new MarioBlockBottom(this));

        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Left, new MarioEnemySide(this));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Right, new MarioEnemySide(this));
        collisionDictionary[typeof(IEnemy)].Add(CollisionDirection.Bottom, new MarioEnemyBottom(this));
    }

    public void MarioEnemyCollision(IEntityBase Enemy)
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
 