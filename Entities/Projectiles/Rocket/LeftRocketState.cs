using Mario.Entities.Abstract;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles.Rocket
{
    public class LeftRocketState : AbstractEntityState
    {
        private RocketProjectile rocket;
        public LeftRocketState(RocketProjectile rocket) : base()
        {
            this.rocket = rocket;
            sprite = spriteFactory.CreateSprite("leftRocket");
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            rocket.GetPhysics().Update();
        }
    }
}
