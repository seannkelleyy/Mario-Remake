using Mario.Entities.Abstract;

public class CrouchFireState : AbstractEntityState
{
    public CrouchFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightCrouchFireMario");
    }
}