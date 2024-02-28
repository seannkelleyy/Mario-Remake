using Mario.Entities.Character.HeroStates;

public class StandingRightState : HeroState
{
    public StandingRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandFireMario");
    }
}