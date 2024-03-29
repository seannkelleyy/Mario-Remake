using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

public class Goomba : AbstractCollideable, IEnemy
{
    private double deadTimer = 0f;

    public Goomba(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new LeftMovingGoombaState();
    }

    public override void Update(GameTime gameTime)
    {
        // Reset all collision states to false at the start of each update
        foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
        {
            SetCollisionState((CollisionDirection)direction, false);
        }
        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        if (deadTimer > 0)
        {
            deadTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (deadTimer > 3)
            {
                GameContentManager.Instance.RemoveEntity(this);
            }
        }
        else
        {
            physics.Update();
        }

    }

    public void Stomp()
    {
        if (deadTimer > 0) return;
        currentState = new StompedGoombaState();
        position.Y += 8;
        deadTimer = 1;
    }

    public void Flip()
    {
        currentState = new FlippedGoombaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.isRight)
        {
            physics.isRight = false;
            currentState = new LeftMovingGoombaState();
        }
        else
        {
            physics.isRight = true;
            currentState = new RightMovingGoombaState();
        }
    }

    public bool ReportIsAlive()
    {
        return deadTimer == 0 ? true : false;
    }
}
