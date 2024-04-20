using Mario.Entities.Abstract;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles.Rocket
{
    public class RightRocketState : AbstractEntityState
    {
        private RocketProjectile rocket;
        public RightRocketState(RocketProjectile rocket) : base()
        {
            this.rocket = rocket;
            sprite = spriteFactory.CreateSprite("rightRocket");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            rocket.GetPhysics().Update();
        }
    }
}
