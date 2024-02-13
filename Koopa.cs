using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;

public class Koopa : IEnemy
{
    public IEnemyState state;

    public Koopa()
    {
        state = new LeftMovingKoopaState(this);
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

public class LeftMovingKoopaState : IGoombaState
{
    private Koopa koopa;

    public LeftMovingKoopaState(Koopa koopa)
    {
        this.koopa = koopa;
        // construct koopa's sprite here too
    }

    public void ChangeDirection()
    {
        koopa.state = new RightMovingKoopaState(koopa);
    }

    public void BeStomped()
    {
        koopa.state = new StompedKoopaState(koopa);
    }

    public void BeFlipped()
    {
        koopa.state = new FlippedKoopaState(koopa);
    }

    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}

public class RightMovingKoopaState : IEnemyState
{
    private Koopa koopa;

    public RightMovingKoopaState(Koopa koopa)
    {
        this.koopa = koopa;
        // construct goomba's sprite here too
    }

    public void ChangeDirection()
    {
        koopa.state = new LeftMovingKoopaState(koopa);
    }

    public void BeStomped()
    {
        koopa.state = new StompedKoopaState(koopa);
    }

    public void BeFlipped()
    {
        koopa.state = new FlippedKoopaState(koopa);
    }

    public void Update()
    {
        // call something like goomba.MoveLeft() or goomba.Move(-x,0);
    }
}

public class StompedKoopaState : IEnemyState
{
    private Koopa koopa;

    public StompedKoopaState(Koopa koopa)
    {
        this.koopa = koopa;
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

public class FlippedKoopaState : IEnemyState
{
    private Koopa koopa;

    public FlippedKoopaState(Koopa koopa)
    {
        this.koopa = koopa;
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
