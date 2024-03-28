using Mario.Entities.Abstract;

public class MovingLeftState : AbstractEntityState
{
    public MovingLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunMario");
    }
}