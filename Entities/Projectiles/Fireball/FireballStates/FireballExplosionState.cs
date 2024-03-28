using Mario.Entities.Abstract;
using Mario.Sprites;

namespace Mario.Entities.Projectiles
{
    public class FireballExplosionState : AbstractEntityState
    {
        public FireballExplosionState() : base()
        {
            sprite = SpriteFactory.Instance.CreateSprite("fireballExplosion");
        }
    }
}
