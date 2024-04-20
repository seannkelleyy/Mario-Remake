using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Enemies;
using Mario.Entities.Items;
using Mario.Entities.Projectiles;
using Mario.Entities.Projectiles.Rocket;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using static Mario.Global.GlobalVariables;

public class Goomba : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public ISprite WeaponSprite;
    public EnemyHealth currentHealth = EnemyHealth.Normal;
    private double deadTimer = 0.0f;
    private double attackCounter = 0.0f;
    public bool teamMario { get; }

    public Goomba(Vector2 position, bool isRight)
    {
        physics = new EntityPhysics(this);
        teamMario = false;
        this.position = position;
        if (!isRight)
        {
            ChangeDirection();
        }
        currentState = new MovingGoombaState();
        WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
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
            attackCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (attackCounter > EntitySettings.EnemyAttackCounter)
            {
                Attack();
                attackCounter = 0.0f;
            }
        }
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        WeaponSprite.Draw(spriteBatch, position);
    }

    public void Stomp()
    {
        if (deadTimer > 0) return;
        else if (currentHealth is EnemyHealth.Normal)
        {
            currentState = new StompedGoombaState();
            position.Y += HalfBlockAdjustment;
            deadTimer = 1;
        }
        else if (currentHealth is EnemyHealth.Big)
        {
            currentHealth = EnemyHealth.Normal;
        }
        else
        {
            currentHealth = EnemyHealth.Big;
        }
        WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
        MediaManager.Instance.PlayEffect(EffectNames.stomp);
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(EffectNames.kick);
        currentState = new FlippedGoombaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void Collect(IItem item)
    {
        if (item is FireFlower)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            if (currentHealth != EnemyHealth.Fire)
            {
                currentHealth = EnemyHealth.Fire;
                WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
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
        else if (item is Pistol)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            currentHealth = EnemyHealth.Pistol;
            WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());

        }
        else if (item is Shotgun)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            currentHealth = EnemyHealth.Shotgun;
            WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());

        }
        else if (item is RocketLauncher)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            currentHealth = EnemyHealth.RocketLauncher;
            WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
        }

    }

    public void Attack()
    {
        if (currentHealth is EnemyHealth.Fire)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyFire);
            GameContentManager.Instance.AddEntity(new Fireball(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario));
        }
        else if (currentHealth is EnemyHealth.Pistol)
        {
            GameContentManager.Instance.AddEntity(new BulletObject(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario));
        }
        else if (currentHealth is EnemyHealth.RocketLauncher)
        {
            GameContentManager.Instance.AddEntity(new RocketProjectile(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario));
        }
        else if (currentHealth is EnemyHealth.Shotgun)
        {
            new ShotgunBurst(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario);
        }
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == HorizontalDirection.right)
        {
            physics.currentHorizontalDirection = HorizontalDirection.left;
            WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
        }
        else
        {
            physics.currentHorizontalDirection = HorizontalDirection.right;
            WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
        }
    }

    public bool ReportIsAlive()
    {
        return deadTimer < 1 ? true : false;
    }
    public EnemyHealth ReportHealth()
    {
        return currentHealth;
    }
    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
