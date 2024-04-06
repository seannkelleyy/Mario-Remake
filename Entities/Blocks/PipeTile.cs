using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class PipeTile : AbstractBlock
    {
        public PipeTile(Vector2 position, bool isCollidable, bool isBreakable)
        {
            this.position = position;
            currentState = new PipeTileState();
            this.isCollidable = isCollidable;
            this.isBreakable = isBreakable;
        }
        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
