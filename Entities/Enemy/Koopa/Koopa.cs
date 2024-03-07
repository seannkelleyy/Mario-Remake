using Mario.Entities.Enemy.Koopa.KoopaStates;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

// This class currently isn't being used in sprint 2
public class Koopa : IEnemy
{
    public KoopaState currentState;
    private Vector2 position;
    private EntityPhysics physics;

    public Koopa(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new LeftMovingKoopaState();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
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
        return this.position;
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public void HandleCollision(ICollideable entity, Dictionary<CollisionDirection, bool> collisionDirection)
    {
        if (collisionDirection[CollisionDirection.Top] && entity is IHero)
        {
            Flip();
        }
        else if (collisionDirection[CollisionDirection.Left] || collisionDirection[CollisionDirection.Right])
        {
            ChangeDirection();
        }
    }
}

