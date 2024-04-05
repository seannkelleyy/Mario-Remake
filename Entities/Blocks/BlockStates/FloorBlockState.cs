using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class FloorBlockState : AbstractEntityState
    {
        public FloorBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("floorTile");
        }
    }
}
