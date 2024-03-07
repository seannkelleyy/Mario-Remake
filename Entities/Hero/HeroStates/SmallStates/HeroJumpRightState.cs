using Mario.Entities.Character.HeroStates;

public class JumpRightState : HeroState
{
    public JumpRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpMario");
    }
}