using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public BlockState currentState;
        public Vector2 position;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public virtual void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public abstract void GetHit();
    }
}
