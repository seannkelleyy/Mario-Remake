﻿using GreenGame.Enemy.Koopa;
using GreenGame.Interfaces;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Koopa 
{
    public IEnemyState state;

    public Koopa()
    {
        state = new LeftMovingKoopaState(this);
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


