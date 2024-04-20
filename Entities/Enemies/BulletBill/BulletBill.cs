using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Enemies;
using Mario.Entities.Items;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using static Mario.Global.GlobalVariables;

public class BulletBill : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public VerticalEntityPhysics verticalPhysics { get; }
    private double deadTimer = 0.0f;
    private EnemyHealth currentHealth = EnemyHealth.Normal;
    public bool teamMario { get; }

    public BulletBill(Vector2 position)
    {
        this.position = position;
        teamMario = false;
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

    public EnemyHealth ReportHealth()
    {
        return currentHealth;
    }

    public void Collect(IItem item)
    {
        if (item is FireFlower)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            if (currentHealth != EnemyHealth.Fire)
            {
                currentHealth = EnemyHealth.Fire;
            }
        }
        else if (item is Mushroom)
        {
            // Let it respawn?
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            if (((Mushroom)item).IsOneUp())
            {
                GameContentManager.Instance.AddEntity(this);
                return;
            }
            if (currentHealth == EnemyHealth.Normal)
            {
                currentHealth = EnemyHealth.Big;
            }
        }
        else if (item is Star)
        {
            MediaPlayer.Pause();
            MediaManager.Instance.PlayTheme(SongThemes.enemyStar, true);
            GameContentManager.Instance.RemoveEntity(this);
            GameContentManager.Instance.AddEntity(new StarEnemy(this));
        }

    }

    public Vector2 GetVelocity()
    {
        return new Vector2(position.X - PhysicsSettings.BulletBillSpeed, position.Y);
    }

    public void Attack()
    {
        if (currentHealth is EnemyHealth.Fire)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyFire);
            GameContentManager.Instance.AddEntity(new Fireball(position + new Vector2(0, (this.GetRectangle().Height / 2)), HorizontalDirection.left, teamMario));
        }
    }
}
