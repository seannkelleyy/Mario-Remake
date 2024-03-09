using Mario.Interfaces.Base;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entities.Projectiles
{
    internal class Fireball : IEntityBase
    {
        IFireballState fireballState;
        bool exploded;
        public Fireball(Vector2 position, bool facingLeft)
        {
            fireballState = new FireballMovingState(position, facingLeft);
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
                fireballState = new FireballExplosionState(((FireballMovingState)fireballState).GetPosition(),this);
                exploded = true;
            }
        }
    }
}
