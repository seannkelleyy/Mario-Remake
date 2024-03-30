using Mario.Entities.Abstract;

public class MovingRightState : AbstractEntityState
{
    public MovingRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunMario");
    }
}