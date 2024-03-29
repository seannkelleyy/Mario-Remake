using Mario.Entities.Abstract;
public class JumpRightState : AbstractEntityState
{
    public JumpRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpMario");
    }
}