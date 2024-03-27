using Mario.Collisions;
using Mario.Entities.Enemy.Koopa.KoopaStates;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

public class Koopa : IEnemy
{
    public KoopaState currentState;
    private Vector2 position;
    private EntityPhysics physics;
    public bool isShell = false;
    private Dictionary<CollisionDirection, bool> collisionStates = new Dictionary<CollisionDirection, bool>()
    {
        { CollisionDirection.Top, false },
        { CollisionDirection.Bottom, false },
        { CollisionDirection.Left, false },
        { CollisionDirection.Right, false },
        { CollisionDirection.None, true }
    };

    public Koopa(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new RightMovingKoopaState();
    }

    public void Update(GameTime gameTime)
    {
        // Reset all collision states to false at the start of each update
        foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
        {
            SetCollisionState((CollisionDirection)direction, false);
        }
        CollisionManager.Instance.Run(this);
        physics.Update();
        currentState.Update(gameTime);
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        currentState.Draw(spriteBatch, position);
    }

    public void Stomp()
    {
        if (isShell)
        {
            GameContentManager.Instance.RemoveEntity(this);
        }
        else
        {
            currentState = new StompedKoopaState();
            isShell = true;
        }
    }

    public void Flip()
    {
        currentState = new FlippedKoopaState();
        GameContentManager.Instance.RemoveEntity(this);
    }

    public void ChangeDirection()
    {
        if (physics.horizontalDirection)
        {
            physics.horizontalDirection = false;
            currentState = new LeftMovingKoopaState();
        }
        else
        {
            physics.horizontalDirection = true;
            currentState = new RightMovingKoopaState();
        }
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public bool GetCollisionState(CollisionDirection direction)
    {
        return collisionStates[direction];
    }

    public void SetCollisionState(CollisionDirection direction, bool state)
    {
        collisionStates[direction] = state;
    }

    public Rectangle GetRectangle()
    {
        return new Rectangle((int)position.X, (int)position.Y, (int)currentState.GetVector().X, (int)currentState.GetVector().Y);
    }

    public Vector2 GetVelocity()
    {
        return physics.GetVelocity();
    }
}
