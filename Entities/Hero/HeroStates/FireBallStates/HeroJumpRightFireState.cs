using Mario.Entities.Character.HeroStates;

public class JumpRightFireState : HeroState
{
    public JumpRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpFireMario");
    }
}