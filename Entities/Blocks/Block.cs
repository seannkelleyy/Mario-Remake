using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Sprites
{
    public class Block : IBlock
    {
        private ISprite[] Blocks;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;
        private Vector2 position;

        public Block(ISprite[] blocks, Vector2 position)
        {
            this.position = position;
            Blocks = blocks;
            currentSprite = blocks[indexOfCurrentSprite];
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

        // Changes the current sprite to be handled to the next block in the list
        public void CycleBlockNext()
        {
            if (indexOfCurrentSprite == Blocks.Length - 1)
            {
                indexOfCurrentSprite = 0;
            }
            else
            {
                indexOfCurrentSprite++;
            }
            currentSprite = Blocks[indexOfCurrentSprite];
        }

        // Changes the current sprite to be handled to the previous block in the list
        public void CycleBlockPrev()
        {
            if (indexOfCurrentSprite == 0)
            {
                indexOfCurrentSprite = Blocks.Length - 1;
            }
            else
            {
                indexOfCurrentSprite--;
            }
            currentSprite = Blocks[indexOfCurrentSprite];
        }
    }
}
