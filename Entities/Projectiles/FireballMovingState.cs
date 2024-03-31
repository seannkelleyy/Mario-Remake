using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Mario.Physics.HeroPhysics;

namespace Mario.Entities.Projectiles
{
    internal class FireballMovingState : IFireballState
    {
        private ISprite fireballSprite;
        private Vector2 position;
        private float verticleVelocity = 0;
        private float horizontalVelocity;
        public FireballMovingState(Vector2 position, horizontalDirection currentHorizontalDirection)
        {
            if (currentHorizontalDirection == horizontalDirection.left)
            {
                position = Vector2.Add(position, new Vector2(0, 16));
                horizontalVelocity = -6.25f;
            }
            else
            {
                position = Vector2.Add(position, new Vector2(16, 16));
                horizontalVelocity = 6.25f;
            }
            this.position = position;
            fireballSprite = SpriteFactory.Instance.CreateSprite("fireball");
        }
        public void Update(GameTime gameTime)
        {
            fireballSprite.Update(gameTime);
            position.X += horizontalVelocity;
            position.Y += verticleVelocity;
            verticleVelocity += .9375f;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fireballSprite.Draw(spriteBatch, position);
        }
        public void Bounce()
        {
            verticleVelocity = -3.75f;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
