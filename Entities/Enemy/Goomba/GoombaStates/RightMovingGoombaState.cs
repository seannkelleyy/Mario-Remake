using Mario.Entities.Enemy.Goomba.GoombaStates;

public class RightMovingGoombaState : GoombaState
{
    public RightMovingGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightGoomba");
    }
}