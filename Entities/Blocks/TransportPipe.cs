using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class TransportPipe : AbstractBlock
    {
        public TransportPipe(Vector2 position, bool collidable)
        {
            this.position = position;
            currentState = new PipeTransportState();
            isCollidable = collidable;
        }
        public override void GetHit()
        {
            //Pipes aren't breakable
        }
    }
}
