using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class InvisibleBlockState : AbstractEntityState
    {
        public InvisibleBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("invisibleBlock");
        }
    }
}
