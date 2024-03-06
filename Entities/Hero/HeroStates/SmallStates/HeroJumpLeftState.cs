using Mario.Entities.Character.HeroStates;

public class JumpLeftState : HeroState
{
    public JumpLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpMario");
    }
}