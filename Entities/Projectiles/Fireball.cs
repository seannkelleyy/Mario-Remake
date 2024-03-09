using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Projectiles
{
    internal class Fireball : IEntityBase
    {
        IFireballState fireballState;
        bool exploded;
        public Fireball(Vector2 position, bool facingRight)
        {
            fireballState = new FireballMovingState(position, facingRight);
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
