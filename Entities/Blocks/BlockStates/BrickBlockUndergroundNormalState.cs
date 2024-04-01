using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class BrickBlockUndergroundNormalState : AbstractEntityState
    {
        public BrickBlockUndergroundNormalState() : base()
        {
            sprite = spriteFactory.CreateSprite("brickTileUnderground");
        }
    }
}
