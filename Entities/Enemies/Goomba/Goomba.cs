﻿using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Enemies;
using Mario.Entities.Projectiles;
using Mario.Entities.Items;
using Mario.Global.Settings;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class Goomba : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public EnemyHealth currentHealth = EnemyHealth.Fire;
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
            Attack();
        }
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
            if (currentHealth != EnemyHealth.Fire)
            {
                //bool wasSmall = currentHealth == EnemyHealth.Normal;
                currentHealth = EnemyHealth.Fire;
                //currentState.PowerUp(wasSmall);
            }
        }
        else if (item is Mushroom)
        {
            // Let it respawn?
            if (((Mushroom)item).IsOneUp())
            {
                GameContentManager.Instance.AddEntity(this);
                return;
            }
            if (currentHealth == EnemyHealth.Normal)
            {
                currentHealth = EnemyHealth.Big;
                position.Y += BlockHeightWidth;
                //currentState.PowerUp(true);
            }
        }
        else if (item is Star)
        {
            GameContentManager.Instance.RemoveEntity(this);
            GameContentManager.Instance.AddEntity(new StarEnemy(this));
        }

    }

    public void Attack()
    {
        if (currentHealth is EnemyHealth.Fire)
        {
            MediaManager.Instance.PlayEffect(EffectNames.enemyFire);
            GameContentManager.Instance.AddEntity(new Fireball(this.position, physics.currentHorizontalDirection));
        }
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
    public EnemyHealth ReportHealth()
    {
        return currentHealth;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
