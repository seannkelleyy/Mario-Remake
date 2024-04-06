using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates;

public class PipeTubeHorizontalState : AbstractEntityState
{
    public PipeTubeHorizontalState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTubeSideways");
    }
}
