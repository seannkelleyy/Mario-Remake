using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        public BrickBlock(Vector2 position, bool breakable, bool collidable, string item)
        {
            this.position = position;
            currentState = new BrickBlockNormalState();
            isCollidable = collidable;
            isBreakable = breakable;
        }

        // Block will be broken
        public override void GetHit()
        {
            currentState = new BrickBlockBrokenState();
        }
    }
}
