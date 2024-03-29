using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

public class Koopa : AbstractCollideable, IEnemy
{
    public bool isShell = false;

    public Koopa(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new RightMovingKoopaState();
    }

    public override void Update(GameTime gameTime)
    {
        // Reset all collision states to false at the start of each update
        foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
        {
            SetCollisionState((CollisionDirection)direction, false);
        }
        CollisionManager.Instance.Run(this);
        physics.Update();
        currentState.Update(gameTime);
    }

    public void Stomp()
    {
        if (isShell)
        {
            GameContentManager.Instance.RemoveEntity(this);
        }
        else
        {
            currentState = new StompedKoopaState();
            isShell = true;
            position.Y += 8;
        }
    }

    public void Flip()
    {
        currentState = new FlippedKoopaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.isRight)
        {
            physics.isRight = false;
            if (!isShell)
                currentState = new LeftMovingKoopaState();
        }
        else
        {
            physics.isRight = true;
            if (!isShell)
                currentState = new RightMovingKoopaState();
        }
    }

    public bool ReportHealth()
    {
        return true;
    }
}
