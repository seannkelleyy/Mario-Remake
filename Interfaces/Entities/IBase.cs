using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces.Entities
{
    public interface IBase
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}
