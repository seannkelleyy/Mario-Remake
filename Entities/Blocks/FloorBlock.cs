using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Blocks
{
    // Does not implement IBlock because it doesn't need the GetHit method. The block will only be drawn and won't do anything else
    public class FloorBlock : IEntityBase 
    {
        private BlockState currentState;
        private Vector2 position;

        public FloorBlock (Vector2 position)
        {
            this.position = position;
            currentState = new FloorBlockState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }
    }
}
