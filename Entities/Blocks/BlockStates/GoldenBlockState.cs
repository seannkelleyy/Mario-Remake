using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class GoldenBlockState : AbstractEntityState
    {
        public GoldenBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("questionMarkTile");
        }
    }
}
