using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class MarioEnemyBottom
{
    MarioCollisionHandler handler;
    public MarioEnemyBottom(MarioCollisionHandler Handler)
    {
        this.handler = Handler;
    }

    public void Execute()
    {
        handler.enemy.Stomp();
        handler.mario.Jump();
    }
}