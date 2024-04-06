using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates;

public class PipeTubeVerticalState : AbstractEntityState
{
    public PipeTubeVerticalState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTube");
    }
}
