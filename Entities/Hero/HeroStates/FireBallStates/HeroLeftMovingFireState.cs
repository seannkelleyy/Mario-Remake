using Mario.Entities.Character.HeroStates;

public class LeftMovingFireState : HeroState
{
    public LeftMovingFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunFireMario");
    }
}