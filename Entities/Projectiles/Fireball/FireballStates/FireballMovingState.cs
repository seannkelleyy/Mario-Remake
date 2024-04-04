using Mario.Entities.Abstract;
using Mario.Sprites;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles
{
    public class FireballMovingState : AbstractEntityState
    {
        private Fireball fireball;
        public FireballMovingState(Fireball fireball, bool isRight) : base()
        {
            sprite = SpriteFactory.Instance.CreateSprite("fireball");
            this.fireball = fireball;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            fireball.GetPhysics().Update();
        }
    }
}