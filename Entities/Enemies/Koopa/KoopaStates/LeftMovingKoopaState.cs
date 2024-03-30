using Mario.Entities.Abstract;

public class LeftMovingKoopaState : AbstractEntityState
{
    public LeftMovingKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftKoopa");
    }
}