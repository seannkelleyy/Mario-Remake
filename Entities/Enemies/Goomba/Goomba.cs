using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class Goomba : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    private double deadTimer = 0f;
    private MediaManager mediaManager = MediaManager.Instance;

    public Goomba(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new LeftMovingGoombaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        if (deadTimer > 0)
        {
            deadTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (deadTimer > EntitySettings.enemyDespawnTime)
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
        mediaManager.PlayEffect(MediaManager.EffectNames.stomp);
        currentState = new StompedGoombaState();
        position.Y += halfBlockAdjustment;
        deadTimer = 1;
    }

    public void Flip()
    {
        mediaManager.PlayEffect(MediaManager.EffectNames.kick);
        currentState = new FlippedGoombaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == horizontalDirection.right)
        {
            physics.currentHorizontalDirection = horizontalDirection.left;
            currentState = new LeftMovingGoombaState();
        }
        else
        {
            physics.currentHorizontalDirection = horizontalDirection.right;
            currentState = new RightMovingGoombaState();
        }
    }

    public bool ReportIsAlive()
    {
        return deadTimer == 0 ? true : false;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
