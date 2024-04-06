using Mario.Entities.Abstract;

namespace Mario.Entities.Pipes.PipeStates;

public class PipeTileState : AbstractEntityState
{
    public PipeTileState() : base()
    {
        sprite = spriteFactory.CreateSprite("pipeTile");
    }
}
