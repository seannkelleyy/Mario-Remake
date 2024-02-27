using Mario.Entities.Enemy.Goomba.GoombaStates;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

// This class currently isn't being used in sprint 2
public class Goomba : IEnemy
{
    public GoombaState currentState;
    private Vector2 position;
    // Right is true, left is false
    private Boolean direction = true;

    public Goomba(Vector2 position)
    {
        this.position = position;
        currentState = new LeftMovingGoombaState();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentState.Draw(spriteBatch, position);
    }

    public void ChangeDirection()
    {
        direction = !direction;
    }

    public void Stomp()
    {
        currentState = new StompedGoombaState();
    }

    public void Flip()
    {
        currentState = new FlippedGoombaState();
    }

    // These will need edited later
    public void MoveLeft()
    {
        if (position.X == 0)
        {
            ChangeDirection();
        }
        position.X = position.X - 2;
    }

    public void MoveRight()
    {
        //Edit value to whatever the edge of the screen is
        if (position.X == 0)
        {
            ChangeDirection();
        }
        position.X = position.X + 2;
    }

}

