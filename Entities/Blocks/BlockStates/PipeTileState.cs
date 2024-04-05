using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates;

public class PipeTileState : AbstractEntityState
{
    public PipeTileState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTile");
    }
}
