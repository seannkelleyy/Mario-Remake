using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework;
using System;

namespace Mario.Entities.Blocks
{
    // Does not implement IBlock because it doesn't need the GetHit method. The block will only be drawn and won't do anything else
    public class FloorBlock : AbstractBlock
    {
        public bool isCollidable { get; } = true;
        public bool isBreakable { get; } = false;

        public FloorBlock(Vector2 position)
        {
            this.position = position;
            currentState = new FloorBlockState();
        }

        public override void GetHit()
        {
            throw new NotImplementedException();
        }
    }
}
