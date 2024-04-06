using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates;

public class PipeTubeVerticalUpsideDownState : AbstractEntityState
{
    public PipeTubeVerticalUpsideDownState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTubeUpsideDown");
    }
}
