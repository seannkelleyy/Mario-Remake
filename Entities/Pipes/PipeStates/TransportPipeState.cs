using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates
{
    public class TransportPipeState : AbstractEntityState
    {
        public TransportPipeState() : base()
        {
            sprite = spriteFactory.CreateSprite("pipe");
        }
    }
}