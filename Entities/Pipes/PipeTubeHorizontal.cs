using Mario.Entities.Pipes.PipeStates;
using Mario.Entities.Pipes;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Mario.Interfaces.Entities;
using Mario.Entities.Blocks;
using static Mario.Interfaces.IPipe;
using Mario.Global;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Pipes
{
    public class PipeTubeHorizontal : AbstractPipe
    {
        private bool isTransportable;
        private Vector2 transportDestination;

        public PipeTubeHorizontal(Vector2 position, Vector2 transportDestination, bool isCollidable, bool isTransportable)
        {
            this.position = position;
            this.transportDestination = transportDestination;
            currentState = new PipeTubeHorizontalState();
            this.isCollidable = isCollidable;
            this.isTransportable = isTransportable;
            type = GlobalVariables.PipeType.horizontal;
        }

        public override void Transport(IHero mario)
        {
            if (isTransportable)
            {
                mario.SetPosition(transportDestination);
                MediaManager.Instance.PlayEffect(EffectNames.pipe);
            }
        }
    }
}
