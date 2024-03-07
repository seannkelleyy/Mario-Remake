using Mario.Interfaces;
using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public BlockState currentState;
        public Vector2 position;

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public abstract void GetHit();

        public Vector2 GetPosition()
        {
            return this.position;
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
    }
}
