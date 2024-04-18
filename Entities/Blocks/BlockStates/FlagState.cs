using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class FlagState : AbstractEntityState
    {
        public FlagState() : base()
        {
            sprite = spriteFactory.CreateSprite("FlagPole");
        }
    }
}
