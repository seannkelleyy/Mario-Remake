using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        public BrickBlock(Vector2 position, bool breakable, bool collidable, bool isUnderground = false)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            canBeCombined = false;

            if (isUnderground)
            {
                currentState = new BrickBlockUndergroundNormalState();
            } else
            {
                currentState = new BrickBlockNormalState();
            }
        }

        // Block will be broken
        public override void GetHit()
        {

            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
            else currentState = new BrickBlockBrokenState();
        }
    }
}
