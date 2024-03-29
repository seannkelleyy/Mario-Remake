using Mario.Entities.Abstract;

public class RightMovingKoopaState : AbstractEntityState
{
    public RightMovingKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightKoopa");
    }
}