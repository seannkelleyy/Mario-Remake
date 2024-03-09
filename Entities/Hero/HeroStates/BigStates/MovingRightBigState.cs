using Mario.Entities.Character.HeroStates;

public class MovingRightBigState : HeroState
{
    public MovingRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunBigMario");
    }
}