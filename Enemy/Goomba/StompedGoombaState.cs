using GreenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StompedGoombaState : IEnemyState
{
    private Goomba goomba;

    public StompedGoombaState(Goomba goomba)
    {
        this.goomba = goomba;
        // construct goomba's sprite here too
    }

    public void ChangeDirection()
    {
        //NO-OP
    }

    public void BeStomped()
    {
        // NO-OP
        // already stomped, do nothing
    }

    public void BeFlipped()
    {
        // NO-OP
        // if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
    }

    public void Update(GameTime gameTime)
    {
        // call something like goomba.Stomp();
    }
}
