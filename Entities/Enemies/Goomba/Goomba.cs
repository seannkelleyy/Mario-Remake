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
    public VerticalEntityPhysics verticalPhysics { get; }
    private double deadTimer = 0.0f;

    public Goomba(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new MovingGoombaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        if (deadTimer > 0)
        {
            deadTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (deadTimer > EntitySettings.EnemyDespawnTime)
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
        MediaManager.Instance.PlayEffect(EffectNames.stomp);
        currentState = new StompedGoombaState();
        position.Y += HalfBlockAdjustment;
        deadTimer = 1;
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(EffectNames.kick);
        currentState = new FlippedGoombaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == HorizontalDirection.right)
        {
            physics.currentHorizontalDirection = HorizontalDirection.left;
        }
        else
        {
            physics.currentHorizontalDirection = HorizontalDirection.right;
        }
    }

    public bool ReportIsAlive()
    {
        return deadTimer < 1 ? true : false;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
