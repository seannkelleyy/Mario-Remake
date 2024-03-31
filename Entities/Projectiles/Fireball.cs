using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Mario.Physics.HeroPhysics;

namespace Mario.Entities.Projectiles
{
    internal class Fireball : IEntityBase
    {
        IFireballState fireballState;
        bool exploded;
        public Fireball(Vector2 position, horizontalDirection currentHorizontalDirection)
        {
            fireballState = new FireballMovingState(position, currentHorizontalDirection);
            exploded = false;
        }
        public void Update(GameTime gameTime)
        {
            fireballState.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fireballState.Draw(spriteBatch);
        }
        public void Bounce()
        {
            fireballState.Bounce();
        }
        public void Explode()
        {
            if (!exploded)
            {
                fireballState = new FireballExplosionState(((FireballMovingState)fireballState).GetPosition(), this);
                exploded = true;
            }
        }
    }
}
