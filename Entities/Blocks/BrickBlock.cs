using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
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
            canBeCombined = false;
        }

        // Block will be broken
        public override void GetHit()
        {

            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
            else currentState = new BrickBlockBrokenState();
        }
    }
}
