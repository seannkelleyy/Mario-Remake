using Mario.Entities.Character.HeroStates;

public class LeftMovingState : HeroState
{
    public LeftMovingState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunFireMario");
    }
}