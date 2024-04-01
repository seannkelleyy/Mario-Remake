using Mario.Entities.Abstract;
using Mario.Sprites;

namespace Mario.Entities.Projectiles
{
    public class FireballMovingState : AbstractEntityState
    {
        public FireballMovingState() : base()
        {
            sprite = SpriteFactory.Instance.CreateSprite("fireball");
        }
    }
}