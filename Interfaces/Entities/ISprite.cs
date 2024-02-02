using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces
{
    public interface ISprite
    {
        // Returns size of sprite
        public Rectangle GetRectangle();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
