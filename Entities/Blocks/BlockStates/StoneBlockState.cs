using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class StoneBlockState : AbstractEntityState
    {
        public StoneBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("stoneTile");
        }
    }
}
