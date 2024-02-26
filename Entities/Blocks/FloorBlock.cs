using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Blocks
{
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
