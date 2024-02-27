using Mario.Entities.Character.HeroStates;

public class JumpStateLeft : HeroState
{
    public JumpStateLeft() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpMario");
    }
}