using GreenGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RightMovingGoombaState : IEnemy
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

    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }

    public void Update(GameTime gameTime)
    {
        throw new NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        throw new NotImplementedException();
    }
}

