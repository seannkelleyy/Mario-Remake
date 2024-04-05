using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class FloorBlockUndergroundState : AbstractEntityState
    {
        public FloorBlockUndergroundState() : base()
        {
            sprite = spriteFactory.CreateSprite("floorTileUnderground");
        }
    }
}
