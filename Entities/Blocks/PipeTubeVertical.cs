using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class PipeTubeVertical : AbstractBlock
    {
        bool isTransportable;
        public PipeTubeVertical(Vector2 position, bool isCollidable, bool isBreakable, bool isTransportable)
        {
            this.position = position;
            currentState = new PipeTubeState();
            this.isCollidable = isCollidable;
            this.isBreakable = isBreakable;
            this.isTransportable = isTransportable;
        }

        public override void GetHit()
        {
            if (isTransportable)
            {
                Transport();
            } else if (isBreakable)
            {
                GameContentManager.Instance.RemoveEntity(this);
            }
        }

        private void Transport()
        {
            // Transport Mario 
        }
    }
}
