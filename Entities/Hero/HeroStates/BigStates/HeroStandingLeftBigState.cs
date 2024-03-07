using Mario.Entities.Character.HeroStates;

public class StandingLeftBigState : HeroState
{
    public StandingLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandBigMario");
    }
}