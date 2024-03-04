using Mario.Entities.Enemy.Goomba.GoombaStates;
using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

// This class currently isn't being used in sprint 2
public class Goomba : IEnemy
{
    public GoombaState currentState;
    private Vector2 position;
    private EntityPhysics physics;

    public Goomba(Vector2 position)
    {
        physics = new EntityPhysics(this);
        this.position = position;
        currentState = new LeftMovingGoombaState();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
        physics.Update();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentState.Draw(spriteBatch, position);
    }

    public void Stomp()
    {
        currentState = new StompedGoombaState();
    }

    public void Flip()
    {
        currentState = new FlippedGoombaState();
    }

    public void ChangeDirection()
    {
        if (physics.horizontalDirection)
        {
            physics.horizontalDirection = false;
            currentState = new LeftMovingGoombaState();
        }
        else
        {
            physics.horizontalDirection = true;
            currentState = new RightMovingGoombaState();
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

    public void HandleCollision(ICollideable entity, Dictionary<CollisionVariables.CollisionDirection, bool> collisionDirection)
    {
        if (collisionDirection[CollisionDirection.Top] && entity is IHero)
        {
            Stomp();
        }
        else if (collisionDirection[CollisionDirection.Left] || collisionDirection[CollisionDirection.Right])
        {
            ChangeDirection();
        }
    }
}

