using GreenGame.Enemy.Koopa;
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

}


