using Mario.Entities.Abstract;

public class JumpRightFireState : AbstractEntityState
{
    public JumpRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpFireMario");
    }
}