using Mario.Interfaces.Entities;
using Mario.Entities.Pipes.PipeStates;
using Microsoft.Xna.Framework;
using Mario.Entities.Blocks;
using Mario.Global;

namespace Mario.Entities.Pipes
{
    public class PipeTile : AbstractPipe
    {
        
        public PipeTile(Vector2 position, bool isCollidable)
        {
            this.position = position;
            currentState = new PipeTileState();
            this.isCollidable = isCollidable;
            type = GlobalVariables.PipeType.tile;
        }
        public override void Transport(IHero mario)
        {
            // nothing to do here since this is just the pipe tile
        }
    }
}
