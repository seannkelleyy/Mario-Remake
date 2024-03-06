using Mario.Entities.Character.HeroStates;

public class StandingRightFireState : HeroState
{
    public StandingRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandFireMario");
    }
}