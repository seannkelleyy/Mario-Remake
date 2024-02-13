using GreenGame.Enemy.Koopa;
using GreenGame.Interfaces;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Koopa 
{
    public IEnemy state;

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

    public void Update(GameTime gameTime)
    {
        state.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {

    }
}


