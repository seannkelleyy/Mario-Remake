using Microsoft.Xna.Framework;
using Mario.Entities.Blocks.BlockStates;
using System;

namespace Mario.Entities.Blocks
{
    public class EmptyBrickBlock : AbstractBlock
    {
        public Boolean isCollidable { get; } = true;
        public Boolean isBreakable { get; } = true;

        public EmptyBrickBlock(Vector2 position)
        {
            this.position = position;
            currentState = new BrickBlockNormalState();
        }

        // Block will be broken
        public override void GetHit()
        {
            currentState = new BrickBlockBrokenState();
        }
    }
}
