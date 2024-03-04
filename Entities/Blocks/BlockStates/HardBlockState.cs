namespace Mario.Entities.Blocks.BlockStates
{
    public class HardBlockState : BlockState
    {
        public HardBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("stoneTile");
        }
    }
}
