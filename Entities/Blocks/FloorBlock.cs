using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class FloorBlock : AbstractBlock
    {
        public FloorBlock(Vector2 position, bool breakable, bool collidable, bool isUnderground = false)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            canBeCombined = true;

            if (isUnderground)
            {
                currentState = new FloorBlockUndergroundState();
            }
            else
            {
                currentState = new FloorBlockState();
            }
        }

        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
