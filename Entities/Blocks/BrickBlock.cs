using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        private MediaManager mediaManager = MediaManager.Instance;
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
            if (isBreakable)
            {
                mediaManager.PlayEffect(MediaManager.EffectNames.breakBlock);
                GameContentManager.Instance.RemoveEntity(this);
            }
            else
            {
                mediaManager.PlayEffect(MediaManager.EffectNames.bumpBlock);
                currentState = new BrickBlockBrokenState();
            }
        }
    }
}
