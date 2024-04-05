using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class HardBlockState : AbstractEntityState
    {
        public HardBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("stoneTile");
        }
    }
}
