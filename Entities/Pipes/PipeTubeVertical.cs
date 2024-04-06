using Mario.Entities.Pipes.PipeStates;
using Mario.Entities.Pipes;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Mario.Interfaces.Entities;
using Mario.Entities.Blocks;

namespace Mario.Entities.Pipes
{
    public class PipeTubeVertical : AbstractPipe
    {
        private bool isTransportable;
        public PipeTubeVertical(Vector2 position, bool isCollidable, bool isTransportable)
        {
            this.position = position;
            currentState = new PipeTubeVerticalState();
            this.isCollidable = isCollidable;
            this.isTransportable = isTransportable;
        }

        public override void Transport(IHero mario)
        {
            if (isTransportable)
            {
                // Transport mario
            }
        }
    }
}
