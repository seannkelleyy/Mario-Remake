using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class BrickBlockNormalState : AbstractEntityState
    {
        public BrickBlockNormalState() : base()
        {
            sprite = spriteFactory.CreateSprite("brickTile");
        }
    }
}
