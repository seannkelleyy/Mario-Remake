using Mario.Entities.Character.HeroStates;

public class StandingLeftState : HeroState
{
    public StandingLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandFireMario");
    }
}