using Mario.Entities.Character.HeroStates;

public class RightMovingState : HeroState
{
    public RightMovingState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunFireMario");
    }
}