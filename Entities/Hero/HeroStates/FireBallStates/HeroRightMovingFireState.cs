using Mario.Entities.Character.HeroStates;

public class RightMovingFireState : HeroState
{
    public RightMovingFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunFireMario");
    }
}