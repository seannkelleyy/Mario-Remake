using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Abstract
{
	public abstract class AbstractEntityState
	{
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public AbstractEntityState()
        {
            spriteFactory = SpriteFactory.Instance;
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

