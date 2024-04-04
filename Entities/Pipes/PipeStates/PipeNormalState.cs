using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates
{
    public class PipeNormalState : AbstractEntityState
    {
        public PipeNormalState() : base()
        {
            sprite = spriteFactory.CreateSprite("pipe");
        }
    }
}
