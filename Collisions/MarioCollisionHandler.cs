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


    public MarioCollisionHandler(IHero Mario)
    {
        this.mario = Mario;
        //create dictionary of delegates for collision calls
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
        //Traverse dictionary for delegate
    }
}
 