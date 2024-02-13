using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;

public class Goomba : IEnemy
{
    public IEnemyState state;

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

public class LeftMovingGoombaState : IGoombaState
{
    private Goomba goomba;

    public LeftMovingGoombaState(Goomba goomba)
    {
        this.goomba = goomba;
        // construct goomba's sprite here too
    }

    public void ChangeDirection()
    {
        goomba.state = new RightMovingGoombaState(goomba);
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
}

public class RightMovingGoombaState : IGoombaState
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
}

public class StompedGoombaState : IGoombaState
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

    public void Update()
    {
        // call something like goomba.Stomp();
    }
}

public class FlippedGoombaState : IGoombaState
{
    private Goomba goomba;

    public FlippedGoombaState(Goomba goomba)
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

    public void Update()
    {
        // call something like goomba.Flip()
    }
}
