using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Entities.Projectiles
{
    internal class Fireball:IEntityBase
    {
        private ISprite fireballSprite;
        private Vector2 position;
        private float verticleVelocity = 0;
        public Fireball(Vector2 position) { 
            this.position = position;
            fireballSprite = SpriteFactory.Instance.CreateSprite("fireball");
        }
        public void Update(GameTime gameTime) {
            position.X += 6.25f;
            position.Y += verticleVelocity;
            verticleVelocity -= 1.6f;
            
        }
        public void Draw(SpriteBatch spriteBatch) { 
            fireballSprite.Draw(spriteBatch, position);
        }
        public void Bounce() {
            verticleVelocity = 8f;
        }
        public void Explode() {
            fireballSprite = SpriteFactory.Instance.CreateSprite("fireballExplosion");
        }

    }
}
