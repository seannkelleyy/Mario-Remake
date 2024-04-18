using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class EmptyBlockState : AbstractEntityState
    {
        public EmptyBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("emptyBlockTile");
        }
    }
}
