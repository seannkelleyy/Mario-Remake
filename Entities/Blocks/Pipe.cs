using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class Pipe : AbstractBlock
    {
        public Pipe(Vector2 position, bool collidable)
        {
            this.position = position;
            currentState = new PipeNormalState();
            isCollidable = collidable;
        }
        public override void GetHit()
        {
            //Pipes aren't breakable
        }
    }
}
