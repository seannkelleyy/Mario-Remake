using Mario.Entities.Character.HeroStates;

public class StandingRightBigState : HeroState
{
    public StandingRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandBigMario");
    }
}