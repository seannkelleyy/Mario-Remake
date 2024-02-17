using Mario.Entities.Enemy.Koopa;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Koopa : IEnemy
{
    public KoopaState currentState;
    private Vector2 position;
    // Right is true, left is false
    private Boolean direction = true;

    public Koopa()
    {
        currentState = new LeftMovingKoopaState();
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        this.position = position;
        currentState.Draw(spriteBatch, position);
    }

    public void ChangeDirection()
    {
        direction = !direction;
    }

    public void Stomp()
    {
        currentState = new StompedKoopaState();
    }

    public void Flip()
    {
        currentState = new FlippedKoopaState();
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

