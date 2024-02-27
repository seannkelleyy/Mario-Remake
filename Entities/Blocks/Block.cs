using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Sprites
{
    // TODO: This will need to be refactored after adding the IBlock interface
    public class Block : IBlock
    {
        private ISprite currentSprite;
        private Vector2 position;

        public Block(Vector2 position)
        {
            this.position = position;
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
