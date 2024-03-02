using Microsoft.Xna.Framework;
using Mario.Entities.Blocks.BlockStates;
using System;

namespace Mario.Entities.Blocks
{
    public class EmptyBrickBlock : AbstractBlock
    {
        public bool isCollidable { get; } = true;
        public bool isBreakable { get; } = true;

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
