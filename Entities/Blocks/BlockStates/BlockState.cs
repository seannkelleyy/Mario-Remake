using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Blocks.BlockStates
{
    public abstract class BlockState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public BlockState()
        {
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite("brickTile");
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
