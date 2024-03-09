using Mario.Entities.Character.HeroStates;

public class JumpRightBigState : HeroState
{
    public JumpRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpBigMario");
    }
}