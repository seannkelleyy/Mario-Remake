using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using GreenGame.Interfaces;

public class Goomba
{
    public IEnemyState state;
    private Vector2 position;

    public Goomba(Vector2 pos)
    {
        state = new LeftMovingGoombaState(this);
        position = pos;
    }

    public void ChangeDirection()
    {
        state.ChangeDirection();
    }

    public void BeStomped()
    {
        state.BeStomped();
    }

    public void BeFlipped()
    {
        state.BeFlipped();
    }

    // Draw and other methods omitted
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

