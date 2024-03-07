using Mario.Entities.Character.HeroStates;

public class StandingLeftFireState : HeroState
{
    public StandingLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandFireMario");
    }
}