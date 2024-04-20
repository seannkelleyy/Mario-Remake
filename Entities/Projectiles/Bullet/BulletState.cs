using Mario.Entities.Abstract;

namespace Mario.Entities.Projectiles.Bullet
{
    public class BulletState : AbstractEntityState
    {
        public BulletState() : base()
        {
            sprite = spriteFactory.CreateSprite("bulletProjectile");
        }
    }
}
