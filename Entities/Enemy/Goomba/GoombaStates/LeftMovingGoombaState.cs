using Mario.Entities.Enemy.Goomba.GoombaStates;

public class LeftMovingGoombaState : GoombaState
{
    public LeftMovingGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("goomba");
    }
}