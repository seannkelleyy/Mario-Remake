using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Sprites
{
    public class Block : Interfaces.IBlock
    {
        private ISprite[] Blocks;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;

        public Block(ISprite[] blocks)
        {
            Blocks = blocks;
            currentSprite = blocks[indexOfCurrentSprite];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
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
