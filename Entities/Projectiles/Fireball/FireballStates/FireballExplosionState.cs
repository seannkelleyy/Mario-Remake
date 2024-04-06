using Mario.Entities.Abstract;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles
{
    public class FireballExplosionState : AbstractEntityState
    {
        private Fireball fireball;
        private float elapsedSeconds = 0;
        public FireballExplosionState(Fireball fireball) : base()
        {
            sprite = SpriteFactory.Instance.CreateSprite("fireballExplosion");
            this.fireball = fireball;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds > PhysicsSettings.FireballDeleteInterval)
            {
                GameContentManager.Instance.RemoveEntity(fireball);
            }
        }

    }
}
