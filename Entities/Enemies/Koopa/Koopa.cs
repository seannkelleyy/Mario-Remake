using System;
using System.Collections.Generic;
using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Abstract;
using Mario.Entities.Enemies;
using Mario.Entities.Enemies.EnemyAI;
using Mario.Entities.Items;
using Mario.Entities.Projectiles;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using static Mario.Global.GlobalVariables;

public class Koopa : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public EnemyHealth currentHealth = EnemyHealth.Normal;
#nullable enable
    public Dictionary<string, IAI>? EnemyAI { get; set; }
#nullable disable
    private double shellTimer = 0.0;
    private double attackCounter = 0.0f;
    private AbstractEntityState previousState;
    public bool isShell = false;
    public bool teamMario { get; }

    public Koopa(Vector2 position, List<string> ais)
    {
        EnemyAI = new Dictionary<string, IAI>();
        parseAIs(EnemyAI, ais);
        physics = new EntityPhysics(this);
        teamMario = false;
        this.position = position;
        currentState = new RightMovingKoopaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        attackCounter += gameTime.ElapsedGameTime.TotalSeconds;
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

    }

    public void Attack()
    {
        if (currentHealth is EnemyHealth.Fire)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyFire);
            GameContentManager.Instance.AddEntity(new Fireball(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario));
        }
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == HorizontalDirection.right)
        {
            physics.currentHorizontalDirection = HorizontalDirection.left;
            if (!isShell)
                currentState = new LeftMovingKoopaState();
        }
        else
        {
            physics.currentHorizontalDirection = HorizontalDirection.right;
            if (!isShell)
                currentState = new RightMovingKoopaState();
        }
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
}
