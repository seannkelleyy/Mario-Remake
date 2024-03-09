using Mario.Entities.Character.HeroStates;

public class MovingRightState : HeroState
{
    public MovingRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunMario");
    }
}