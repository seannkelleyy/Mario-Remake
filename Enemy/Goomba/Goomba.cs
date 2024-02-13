using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using GreenGame.Interfaces;

public class Goomba
{
    public IEnemy state;

    public Goomba()
    {
        state = new LeftMovingGoombaState(this);
    }

    public void ChangeDirection()
    {
        state.ChangeDirection();
    }

    public void BeStomped()
    {
        state.BeStomped();
    }

    public void BeFlipped()
    {
        state.BeFlipped();
    }

    // Draw and other methods omitted
}

