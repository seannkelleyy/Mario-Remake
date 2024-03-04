namespace Mario.Entities.Blocks.BlockStates
{
    public class FloorBlockState : BlockState
    {
        public FloorBlockState() : base()
        {
            sprite = spriteFactory.CreateSprite("floorTile");
        }
    }
}
