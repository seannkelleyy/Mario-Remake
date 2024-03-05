using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class MarioEnemySide
{
    MarioCollisionHandler handler;
    public MarioEnemySide(MarioCollisionHandler Handler)
    {
        this.handler = Handler;
    }

    public void Execute()
    {
        handler.mario.TakeDamage();
    }
}