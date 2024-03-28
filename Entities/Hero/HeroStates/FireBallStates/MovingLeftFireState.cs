using Mario.Entities.Abstract;

public class MovingLeftFireState : AbstractEntityState
{
    public MovingLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunFireMario");
    }
}