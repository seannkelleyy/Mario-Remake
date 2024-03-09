using Mario.Entities.Enemy.Koopa.KoopaStates;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

// This class currently isn't being used in sprint 2
public class Koopa : IEnemy
{
    public KoopaState currentState;
    private Vector2 position;
    private EntityPhysics physics;
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
        currentState = new LeftMovingKoopaState();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
        physics.Update();

        // Reset all collision states to false at the start of each update
        foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
        {
            SetCollisionState((CollisionDirection)direction, false);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentState.Draw(spriteBatch, position);
    }

    public void Stomp()
    {
        currentState = new StompedKoopaState();
    }

    public void Flip()
    {
        currentState = new FlippedKoopaState();
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

