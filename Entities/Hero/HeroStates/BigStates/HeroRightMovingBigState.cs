using Mario.Entities.Character.HeroStates;

public class RightMovingBigState : HeroState
{
    public RightMovingBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunBigMario");
    }
}