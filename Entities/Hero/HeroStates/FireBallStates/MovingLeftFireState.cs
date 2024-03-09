using Mario.Entities.Character.HeroStates;

public class MovingLeftFireState : HeroState
{
    public MovingLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunFireMario");
    }
}