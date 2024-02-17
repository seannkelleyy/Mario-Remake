using GreenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RightMovingGoombaState : IEnemyState
{
    private Goomba goomba;

    public RightMovingGoombaState(Goomba goomba)
    {
        this.goomba = goomba;
        // construct goomba's sprite here too
    }

    public void ChangeDirection()
    {
        goomba.state = new LeftMovingGoombaState(goomba);
    }

    public void BeStomped()
    {
        goomba.state = new StompedGoombaState(goomba);
    }

    public void BeFlipped()
    {
        goomba.state = new FlippedGoombaState(goomba);
    }

    public void Update(GameTime gameTime)
    {
        goomba.MoveRight()
    }

}

