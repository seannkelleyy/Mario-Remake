using Mario.Entities.Abstract;

public class JumpLeftState : AbstractEntityState
{
    public JumpLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpMario");
    }
}