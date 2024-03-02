using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario.Entities.Blocks
{
    // Does not implement IBlock because it doesn't need the GetHit method. The block will only be drawn and won't do anything else
    public class FloorBlock : IEntityBase
    {
        private BlockState state;
        private Vector2 position;
        public bool isCollidable { get; } = true;
        public bool isBreakable { get; } = false;

        public FloorBlock (Vector2 position)
        {
            this.position = position;
            state = new FloorBlockState();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }
    }
}
