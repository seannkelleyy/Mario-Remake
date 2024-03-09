using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        public BrickBlock(Vector2 position)
        {
            this.position = position;
            currentState = new BrickBlockNormalState();
            isCollidable = true;
            isBreakable = true;
        }

        // Block will be broken
        public override void GetHit()
        {
            currentState = new BrickBlockBrokenState();
        }
    }
}
