using Mario.Entities.Abstract;

namespace Mario.Entities.Blocks.BlockStates;

public class PipeTubeState : AbstractEntityState
{
    public PipeTubeState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTube");
    }
}
