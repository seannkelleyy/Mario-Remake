using Mario.Interfaces;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Sprites
{
    public class Item : IItem
    {
        private ISprite[] items;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;
        private Vector2 position;

        public Item(ISprite[] items, Vector2 position)
        {
            this.position = position;
            this.items = items;
            currentSprite = items[indexOfCurrentSprite];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
        }
    }
}
