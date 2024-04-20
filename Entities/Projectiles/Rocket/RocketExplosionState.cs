using Mario.Entities.Abstract;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles.Rocket
{
    public class RocketExplosionState : AbstractEntityState
    {

        private RocketProjectile rocket;
        private float elapsedSeconds = 0;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds > PhysicsSettings.FireballDeleteInterval)
            {
                GameContentManager.Instance.RemoveEntity(rocket);
            }
        }
        public RocketExplosionState(RocketProjectile rocket) : base()
        {
            this.rocket = rocket;
            sprite = spriteFactory.CreateSprite("bigExplosion");
        }
    }
}
