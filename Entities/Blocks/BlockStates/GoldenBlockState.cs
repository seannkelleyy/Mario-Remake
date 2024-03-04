namespace Mario.Entities.Blocks.BlockStates
{
    public class GoldenBlockState : BlockState
    {
        public GoldenBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("questionMarkTile");
        }
    }
}
