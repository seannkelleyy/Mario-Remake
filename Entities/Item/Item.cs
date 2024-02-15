using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Sprites
{
    public class Item : Interfaces.IItem
    {
        private ISprite[] Items;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;
        private Vector2 position;

        public Item(ISprite[] items, Vector2 itemPosition)
        {
            Items = items;
            currentSprite = items[indexOfCurrentSprite];
            position = itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
        }

        // NOTE: These methods will go bye bye after Sprint 2.

        // Changes the current sprite to be drawn to the next item in the list
        public void CycleItemNext()
        {
            if (indexOfCurrentSprite == Items.Length - 1)
            {
                indexOfCurrentSprite = 0;
            }
            else
            {
                indexOfCurrentSprite++;
            }
            currentSprite = Items[indexOfCurrentSprite];
        }

        // Changes the current sprite to be drawn to the previous item in the list
        public void CycleItemPrev()
        {
            if (indexOfCurrentSprite == 0)
            {
                indexOfCurrentSprite = Items.Length - 1;
            }
            else
            {
                indexOfCurrentSprite--;
            }
            currentSprite = Items[indexOfCurrentSprite];
        }
    }
}
