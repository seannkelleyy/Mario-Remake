using Mario.Entities.Pipes.PipeStates;
using Microsoft.Xna.Framework;
using Mario.Interfaces.Entities;
using Mario.Entities.Blocks;
using Mario.Global;
using Mario.Singletons;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Pipes
{
    public class PipeTubeVertical : AbstractPipe
    {
        private bool isTransportable;
        private Vector2 transportDestination;
        public PipeTubeVertical(Vector2 position, Vector2 transportDestination, bool isCollidable, bool isTransportable)
        {
            this.position = position;
            this.transportDestination = transportDestination;
            currentState = new PipeTubeVerticalState();
            this.isCollidable = isCollidable;
            this.isTransportable = isTransportable;
            type = GlobalVariables.PipeType.vertical;
        }

        public override void Transport(IHero mario)
        {
            if (isTransportable)
            {
                mario.SetPosition(transportDestination);
                MediaManager.Instance.PlayEffect(EffectNames.pipe);
                mario.SetTransportState(true);
            }
        }
    }
}
