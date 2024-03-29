using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class FloorBlock : AbstractBlock
    {
        public FloorBlock(Vector2 position, bool breakable, bool collidable)
        {
            this.position = position;
            currentState = new FloorBlockState();
            isCollidable = collidable;
            isBreakable = breakable;
            canBeCombined = true;
        }

        public override void GetHit()
        {
            Logger.Instance.LogInformation("brick block hit");

            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
