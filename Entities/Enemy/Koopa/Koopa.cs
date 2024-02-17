using Mario.Entities.Enemy;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Koopa : IEnemy
{
    public EnemyState currentState;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    // Right is true, left is false
    private Boolean direction = true;

    public Koopa(SpriteBatch spriteBatch, Vector2 position)
    {
        this.spriteBatch = spriteBatch;
        currentState = new LeftMovingKoopaState(spriteBatch);
        this.position = position;
    }

    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw()
    {
        currentState.Draw(spriteBatch, position);
    }

    public void ChangeDirection()
    {
        direction = !direction;
    }

    public void Stomp()
    {
        currentState = new StompedKoopaState(spriteBatch);
    }

    public void Flip()
    {
        currentState = new FlippedKoopaState(spriteBatch);
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

