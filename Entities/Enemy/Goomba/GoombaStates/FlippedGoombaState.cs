using Mario.Entities.Enemy.Goomba.GoombaStates;

public class FlippedGoombaState : GoombaState
{
    public FlippedGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("flippedGoomba");
    }
}