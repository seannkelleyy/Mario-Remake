using Mario.Entities.Abstract;

public class BulletBillLeftState : AbstractEntityState
{
    public BulletBillLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftBullet");
    }
}