namespace Mario.Entities.Blocks.BlockStates
{
    public class BrickBlockNormalState : BlockState
    {
        public BrickBlockNormalState() : base()
        {
            sprite = spriteFactory.CreateSprite("brickTile");
        }
    }
}
