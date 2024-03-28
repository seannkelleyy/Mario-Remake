using Mario.Entities.Abstract;

public class MovingLeftBigState : AbstractEntityState
{
    public MovingLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunBigMario");
    }
}