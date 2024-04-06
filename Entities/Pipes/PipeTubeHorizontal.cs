using Mario.Entities.Pipes.PipeStates;
using Mario.Entities.Pipes;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Mario.Interfaces.Entities;
using Mario.Entities.Blocks;

namespace Mario.Entities.Pipes
{
    public class PipeTubeHorizontal : AbstractPipe
    {
        private bool isTransportable;

        public PipeTubeHorizontal(Vector2 position, bool isCollidable, bool isTransportable)
        {
            this.position = position;
            currentState = new PipeTubeHorizontalState();
            this.isCollidable = isCollidable;
            this.isTransportable = isTransportable;
        }

        public override void Transport(IHero mario)
        {
            if (isTransportable)
            {
                // change mario's position
            }
        }
    }
}
