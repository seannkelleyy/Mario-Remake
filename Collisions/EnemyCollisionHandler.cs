using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class EnemyCollisionHandler
{
    public IEntityBase enemy { get; set; }
    public IEntityBase enemy2 { get; set; }
    public IBlock block { get; set; }


    public void EnemyCollisionHandler(IEntityBase Enemy)
    {
        enemy = Enemy;
        //create dictionary of delegates for collision calls
    }

    public void EnemyEnemyCollision(IEntityBase Enemy)
    {
        enemy2 = Enemy;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }

    public void EnemyBlockCollision(IBlock Block)
    {
        block = Block;
        //Figure out how to pass rectangle
        CollisionDirection direction = DetectCollision();
        //Traverse dictionary for delegate
    }
}