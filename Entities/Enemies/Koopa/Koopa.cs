using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Mario.Global;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

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
            MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.kick);
            GameContentManager.Instance.RemoveEntity(this);
        }
        else
        {
            MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.stomp);
            currentState = new StompedKoopaState();
            isShell = true;
            position.Y += halfBlockAdjustment;
        }
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.kick);
        currentState = new FlippedKoopaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == horizontalDirection.right)
        {
            physics.currentHorizontalDirection = horizontalDirection.left;
            if (!isShell)
                currentState = new LeftMovingKoopaState();
        }
        else
        {
            physics.currentHorizontalDirection = horizontalDirection.right;
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
