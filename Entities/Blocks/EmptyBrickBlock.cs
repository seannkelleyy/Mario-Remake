using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Entities.Blocks.BlockStates;

namespace Mario.Entities.Blocks
{
    public class EmptyBrickBlock : IBlock
    {
        private BlockState currentState;
        private Vector2 position;

        public EmptyBrickBlock(Vector2 position, string itemName)
        {
            this.position = position;
            currentState = new BrickBlockNormalState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        // Block will be broken
        public void GetHit()
        {
            currentState = new BrickBlockBrokenState();
        }
    }
}
