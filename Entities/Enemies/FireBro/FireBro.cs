using Mario.Collisions;
using Mario.Entities;
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
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;
public class FireBro : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public VerticalEntityPhysics verticalPhysics { get; }
    public EnemyHealth currentHealth = EnemyHealth.Normal;
#nullable enable
    public Dictionary<string, IAI>? EnemyAI { get; set; }
#nullable disable
    private double attackCounter = 0.0f;
    private double deadTimer = 0;
    public bool teamMario { get; }
    private float marioRelativePosition;

    public FireBro(Vector2 position, bool isRight, List<string> ais)
    {
        EnemyAI = new Dictionary<string, IAI>();
        parseAIs(EnemyAI, ais);
        physics = new EntityPhysics(this);
        teamMario = false;
        this.position = position;
        if (!isRight)
        {
            ChangeDirection();
        } else
        {
            currentState = new RightFacingFireBroState();
        }
        
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        marioRelativePosition = GameContentManager.Instance.GetHero().GetPosition().X - position.X;
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
            if (marioRelativePosition < 0 && (physics.currentHorizontalDirection == HorizontalDirection.right))
            {
                ChangeDirection();
            }
            else if (marioRelativePosition > 0 && (physics.currentHorizontalDirection == HorizontalDirection.left))
            {
                ChangeDirection();
            }
            if (attackCounter > EntitySettings.EnemyAttackCounter && (marioRelativePosition < 200 || marioRelativePosition > 200)) 
            {
                Attack();
                attackCounter = 0.0f;
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
    public void Stomp()
    {
        if (deadTimer > 0) return;
        else if (currentHealth is EnemyHealth.Normal)
        {
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
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void Attack()
    {
        MediaManager.Instance.PlayEffect(EffectNames.enemyFire);
        GameContentManager.Instance.AddEntity(new Fireball(this.GetPosition() + new Vector2(0, (this.GetRectangle().Height / 2)), physics.currentHorizontalDirection, teamMario));
    }

    public void ChangeDirection()
    {
        if (physics.currentHorizontalDirection == HorizontalDirection.right)
        {
            physics.currentHorizontalDirection = HorizontalDirection.left;
            currentState = new LeftFacingFireBroState();
        }
        else
        {
            physics.currentHorizontalDirection = HorizontalDirection.right;
            currentState = new RightFacingFireBroState();
        }
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

    public bool ReportIsAlive()
    {
        return true;
    }

    public HorizontalDirection GetCurrentDirection()
    {
        return physics.GetHorizontalDirection();
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