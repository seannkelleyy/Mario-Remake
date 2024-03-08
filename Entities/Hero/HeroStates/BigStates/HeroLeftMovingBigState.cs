using Mario.Entities.Character.HeroStates;

public class LeftMovingBigState : HeroState
{
    public LeftMovingBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunBigMario");
    }
}