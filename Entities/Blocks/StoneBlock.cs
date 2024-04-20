using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class StoneBlock : AbstractBlock
    {
        public StoneBlock(Vector2 position, bool breakable, bool collidable)
        {
            this.position = position;
            isCollideable = collidable;
            isBreakable = breakable;
            canBeCombined = true;
            currentState = new StoneBlockState();
        }

        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
