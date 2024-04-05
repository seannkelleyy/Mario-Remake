using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates
{
    public class BrickBlockBrokenState : AbstractEntityState
    {
        public BrickBlockBrokenState() : base()
        {
            sprite = spriteFactory.CreateSprite("brokenBrickTile");
        }
    }
}
