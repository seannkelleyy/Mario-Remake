using Mario.Entities.Character.HeroStates;

public class MovingLeftState : HeroState
{
    public MovingLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunMario");
    }
}