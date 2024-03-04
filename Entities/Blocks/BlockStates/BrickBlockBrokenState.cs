namespace Mario.Entities.Blocks.BlockStates
{
    public class BrickBlockBrokenState : BlockState
    {
        public BrickBlockBrokenState() : base()
        {
            sprite = spriteFactory.CreateSprite("brokenBrickTile");
        }
    }
}
