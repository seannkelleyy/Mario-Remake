using Mario.Interfaces.Base;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mario.Entities.Projectiles
{
    internal class FireballExplosionState:IFireballState
    {
        private ISprite fireballSprite;
        private Vector2 position;
        private float deleteInterval = .6f;
        private float elapsedSeconds = 0;
        private Fireball thisFireball;
        public FireballExplosionState(Vector2 position,Fireball thisFireball)
        {
            this.thisFireball = thisFireball;
            this.position = position;
            fireballSprite = SpriteFactory.Instance.CreateSprite("fireballExplosion");
        }
        public void Update(GameTime gameTime)
        {
            fireballSprite.Update(gameTime);
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= deleteInterval)
            {
                GameContentManager.Instance.RemoveEntity(thisFireball);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fireballSprite.Draw(spriteBatch, position);
        }
        public void Bounce()
        {
            //cant bounce if exploding
        }
    }
}
