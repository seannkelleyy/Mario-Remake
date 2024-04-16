using Mario.Collisions;
using Mario.Entities;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class BulletBill : AbstractCollideable, IEnemy
{
    private double deadTimer = 0.0f;

    public BulletBill(Vector2 position)
    {
        this.position = position;
        currentState = new BulletBillLeftState();
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
            position.X -= PhysicsSettings.BulletBillSpeed;
        }
    }

    public void Stomp()
    {
        if (deadTimer > 0) return;
        MediaManager.Instance.PlayEffect(EffectNames.stomp);
        currentState = new BulletBillLeftDeadState();
        position.Y += HalfBlockAdjustment;
        deadTimer = 1;
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(EffectNames.kick);
        currentState = new BulletBillLeftDeadState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        // Bullet bills don't change directions
    }

    public bool ReportIsAlive()
    {
        return deadTimer < 1 ? true : false;
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(position.X -= PhysicsSettings.BulletBillSpeed, position.Y);
    }
}
