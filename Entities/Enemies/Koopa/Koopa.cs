using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;

public class Koopa : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public bool isShell = false;

    public Koopa(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new RightMovingKoopaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

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

    public bool ReportIsAlive()
    {
        return true;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
