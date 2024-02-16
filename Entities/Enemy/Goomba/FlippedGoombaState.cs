using Mario.Interfaces;
using Microsoft.Xna.Framework;

public class FlippedGoombaState : IEnemyState
{
    private Goomba goomba;

    public FlippedGoombaState(Goomba goomba)
    {
        this.goomba = goomba;
        // construct goomba's sprite here too
    }

    public void ChangeDirection()
    {
        //NO-OP
    }

    public void BeStomped()
    {
        // NO-OP
        // already stomped, do nothing
    }

    public void BeFlipped()
    {
        // NO-OP
        // if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
    }

    public void Update(GameTime gameTime)
    {
        // call something like goomba.Flip()
    }
}
