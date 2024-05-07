using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Enemies;
using Mario.Entities.Enemies.EnemyAI;
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
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

public class Goomba : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public ISprite WeaponSprite;
    public EnemyHealth currentHealth = EnemyHealth.Normal;
#nullable enable
    public Dictionary<string, IAI>? EnemyAI { get; set; }
#nullable disable
    public VerticalEntityPhysics verticalPhysics { get; }
    private double deadTimer = 0.0f;
    public double scareCD = 30.0f;
    public double scareCounter = 30.0f;
    private double attackCounter = 0.0f;
    private double attackTimer = EntitySettings.EnemyAttackCounter;
    public bool teamMario { get; }

    public Goomba(Vector2 position, bool isRight, List<string> ais)
    {
        EnemyAI = new Dictionary<string, IAI>();
        parseAIs(EnemyAI, ais);
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
            scareCounter += gameTime.ElapsedGameTime.TotalSeconds;
            foreach (IAI ai in EnemyAI.Values)
            {
                if (scareCounter > 3)
                {
                    ai.Seek(this);
                }
                if (ai.Scare(this, scareCD, scareCounter))
                {
                    scareCounter = 0;
                    
                }
            }
            attackCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (attackCounter > attackTimer)
            {
                Attack();
                attackCounter = 0.0f;
                //attackTimer = rnd.NextDouble() + 1;
            }
        }
    }

    public void parseAIs(Dictionary<string, IAI> enemyAI, List<string> ais)
    {
        if (!(ais.Count == 0))
        {
            foreach (string ai in ais)
            {
                if (ai == "seek")
                {
                    enemyAI.Add("seek", new SeekAI());
                }
                if (ai == "scare")
                {
                    enemyAI.Add("scare", new ScareAI());
                }
                if (ai == "jump")
                {
                    enemyAI.Add("jump", new JumpAI());
                }
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
            MediaManager.Instance.PlayEffect(EffectNames.enemyPowerup);
            if (((Mushroom)item).IsOneUp())
            {
                GameContentManager.Instance.AddEntity(ObjectFactory.Instance.CreateEnemy("goomba", new Vector2(this.GetPosition().X + BlockHeightWidth, this.GetPosition().Y), !(this.physics.currentHorizontalDirection == HorizontalDirection.right), new List<string>()));
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
        if (EnemyAI.ContainsKey("jump"))
        {
            EnemyAI["jump"].Jump(this);
        }
        else
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
    public HorizontalDirection GetCurrentDirection()
    {
        return physics.GetHorizontalDirection();
    }
}
