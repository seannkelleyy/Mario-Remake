using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    // Does not implement IBlock because it doesn't need the GetHit method. The block will only be drawn and won't do anything else
    public class FloorBlock : AbstractBlock
    {
        public FloorBlock(Vector2 position, bool breakable, bool collidable, string item)
        {
            this.position = position;
            currentState = new FloorBlockState();
            isCollidable = collidable;
            isBreakable = breakable;
        }

        public override void GetHit()
        {
            if (isBreakable)
            {
                GameContentManager.Instance.RemoveEntity(this);
            }
        }
    }
}
