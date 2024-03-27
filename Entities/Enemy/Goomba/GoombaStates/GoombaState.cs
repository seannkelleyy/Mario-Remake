using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Enemy.Goomba.GoombaStates
{
    public abstract class GoombaState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;
        public GoombaState()
        {
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite("goomba");
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }

        public Vector2 GetVector()
        {
            return sprite.GetVector();
        }
    }
}
