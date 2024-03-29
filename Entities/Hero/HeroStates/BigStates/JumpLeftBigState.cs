using Mario.Entities.Abstract;

public class JumpLeftBigState : AbstractEntityState
{
    public JumpLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpBigMario");
    }
}