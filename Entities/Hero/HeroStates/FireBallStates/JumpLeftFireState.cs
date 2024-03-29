using Mario.Entities.Abstract;

public class JumpLeftFireState : AbstractEntityState
{
    public JumpLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpFireMario");
    }
}