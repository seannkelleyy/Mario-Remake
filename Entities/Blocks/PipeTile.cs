using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class PipeTile : AbstractBlock
    {
        public PipeTile(Vector2 position)
        {
            this.position = position;
            currentState = new PipeTileState();
            isCollidable = true;
            isBreakable = false;
        }
        public override void GetHit()
        {
            // Nothing to do here since this is a normal pipe
        }
    }
}
