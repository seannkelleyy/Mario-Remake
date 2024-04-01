using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class PipeNormalState : AbstractEntityState
    {
        public PipeNormalState() : base()
        {
            sprite = spriteFactory.CreateSprite("pipe"); //Update for exact sprite title
        }
    }
}
