using Mario.Entities.Abstract;

public class CrouchBigState : AbstractEntityState
{
    public CrouchBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightCrouchBigMario");
    }
}