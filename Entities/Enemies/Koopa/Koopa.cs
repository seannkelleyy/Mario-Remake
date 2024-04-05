using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class Koopa : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public bool isShell = false;
    private MediaManager mediaManager = MediaManager.Instance;

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
            mediaManager.PlayEffect(MediaManager.EffectNames.kick);
            GameContentManager.Instance.RemoveEntity(this);
        }
        else
        {
            mediaManager.PlayEffect(MediaManager.EffectNames.stomp);
            currentState = new StompedKoopaState();
            isShell = true;
            position.Y += halfBlockAdjustment;
        }
    }

    public void Flip()
    {
        mediaManager.PlayEffect(MediaManager.EffectNames.kick);
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
