using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Items.ItemStates
{
    public abstract class ItemState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public ItemState()
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

        public Rectangle GetRectangle()
        {
            return sprite.GetRectangle();
        }
    }
}