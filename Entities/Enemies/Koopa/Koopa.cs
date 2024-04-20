using System;
using Mario.Collisions;
using Mario.Entities;
using Mario.Entities.Abstract;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

public class Koopa : AbstractCollideable, IEnemy
{
    public EntityPhysics physics { get; }
    public VerticalEntityPhysics verticalPhysics { get; }
    private double shellTimer = 0.0;
    private AbstractEntityState previousState;
    public bool isShell = false;

    public Koopa(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new RightMovingKoopaState();
    }

    public override void Update(GameTime gameTime)
    {
        ClearCollisions();

        CollisionManager.Instance.Run(this);
        currentState.Update(gameTime);
        HandleShellTime(gameTime);
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
            isShell = true;
            shellTimer = 1;
            MediaManager.Instance.PlayEffect(EffectNames.stomp);
            previousState = currentState;
            currentState = new StompedKoopaState();
            position.Y += HalfBlockAdjustment;
        }
    }

    public void Flip()
    {
        MediaManager.Instance.PlayEffect(EffectNames.kick);
        currentState = new FlippedKoopaState();
        GameContentManager.Instance.RemoveEntity(this);
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

    public bool ReportIsAlive()
    {
        return true;
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
