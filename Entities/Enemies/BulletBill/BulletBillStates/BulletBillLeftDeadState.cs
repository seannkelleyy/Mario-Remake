using Mario.Entities.Abstract;

public class BulletBillLeftDeadState : AbstractEntityState
{
    public BulletBillLeftDeadState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftBulletFlipped");
    }
}