using Mario.Entities.Abstract;

public class JumpRightBigState : AbstractEntityState
{
    public JumpRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpBigMario");
    }
}