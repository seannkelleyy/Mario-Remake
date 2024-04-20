using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Abstract;
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

public class Koopa : AbstractCollideable, IEnemy

{
    public ISprite WeaponSprite;
    public EntityPhysics physics { get; }
    public VerticalEntityPhysics verticalPhysics { get; }
    public EnemyHealth currentHealth = EnemyHealth.Normal;
#nullable enable
    public Dictionary<string, IAI>? EnemyAI { get; set; }
#nullable disable
    private double shellTimer = 0.0;
    private double attackCounter = 0.0f;
    public double scareCounter = 30.0f;
    public double scareCD = 30.0f;
    private AbstractEntityState previousState;
    public bool isShell = false;

    public bool teamMario { get; }

    public Koopa(Vector2 position, bool isRight, List<string> ais)
    {
        EnemyAI = new Dictionary<string, IAI>();
        parseAIs(EnemyAI, ais);
        physics = new EntityPhysics(this);
        teamMario = false;
        this.position = position;
        if (!isRight)
        {
            currentState = new LeftMovingKoopaState();
            physics.currentHorizontalDirection = HorizontalDirection.left;
        }
        else
        {
            currentState = new RightMovingKoopaState();
        }
        WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        WeaponSprite.Draw(spriteBatch, position);
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        attackCounter += gameTime.ElapsedGameTime.TotalSeconds;
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
        if (attackCounter > EntitySettings.EnemyAttackCounter)
        {
            Attack();
            attackCounter = 0.0f;
        }
        HandleShellTime(gameTime);
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

    private void HandleShellTime(GameTime gameTime)
    {
        if (shellTimer > 0)
        {
            if (physics.GetVelocity().X == 0)
            {
                shellTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                physics.Update();
                shellTimer = 0;
            }
            if (shellTimer > EntitySettings.KoopaShellTime)
            {
                currentState = previousState;
                position.Y -= BlockHeightWidth / 2;
                shellTimer = 0;
                isShell = false;
            }
            else if (shellTimer > EntitySettings.KoopaShellTime / 2)
            {
                currentState = new ArmsOutOfShellKoopaState();
            }
        }
        else
        {
            physics.Update();
        }
    }

    public void Stomp()
    {
        if (isShell)
        {
            MediaManager.Instance.PlayEffect(EffectNames.kick);
            physics.ToggleIsStationary();
        }
        else
        {
            if (currentHealth is EnemyHealth.Normal)
            {
                isShell = true;
                shellTimer = 1;
                MediaManager.Instance.PlayEffect(EffectNames.stomp); // Play Effect outside of if statements.
                previousState = currentState;
                currentState = new StompedKoopaState();
                position.Y += HalfBlockAdjustment;
            }
            else if (currentHealth is EnemyHealth.Big)
            {
                currentHealth = EnemyHealth.Normal;
            }
            else
            {
                currentHealth = EnemyHealth.Big;
                WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
            }
        }
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(EffectNames.kick);
        currentState = new FlippedKoopaState();
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
        if (EnemyAI.ContainsKey("jump"))
        {
            EnemyAI["jump"].Jump(this);
        }
        else
        {
            if (physics.currentHorizontalDirection == HorizontalDirection.right)
            {
                physics.currentHorizontalDirection = HorizontalDirection.left;
                if (!isShell)
                {
                    currentState = new LeftMovingKoopaState();
                    WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
                }
                
            }
            else
            {
                physics.currentHorizontalDirection = HorizontalDirection.right;
                if (!isShell)
                {
                    currentState = new RightMovingKoopaState();
                    WeaponSprite = SpriteFactory.Instance.CreateSprite(physics.currentHorizontalDirection.ToString() + currentHealth.ToString());
                }

            }
        }
    }

    public bool GetIsShell()
    {
        return isShell;
    }
    public void ChangeCurrentState(AbstractEntityState state)
    {
        currentState = state;
    }
    public EnemyHealth ReportHealth()
    {
        return currentHealth;
    }

    public bool ReportIsAlive()
    {
        return true;
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
