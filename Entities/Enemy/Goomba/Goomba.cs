using Mario.Entities.Enemy;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Goomba : IEnemy
{
    public EnemyState currentState;
    private SpriteBatch spriteBatch;
    private Vector2 position;
    // Right is true, left is false
    private Boolean direction = true;

    public Goomba(SpriteBatch spriteBatch, Vector2 position)
    {
        this.spriteBatch = spriteBatch;
        currentState = new LeftMovingGoombaState(spriteBatch);
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
        currentState = new StompedGoombaState(spriteBatch);
    }

    public void Flip()
    {
        currentState = new FlippedGoombaState(spriteBatch);
    }
    
    // These will need edited later
    public void MoveLeft(){
        if(position.X == 0){
            ChangeDirection();
        }
        position.X = position.X - 2;
    }

    public void MoveRight(){
        //Edit value to whatever the edge of the screen is
        if(position.X == 0){
            ChangeDirection();
        }
        position.X = position.X + 2;
    }
    
}

