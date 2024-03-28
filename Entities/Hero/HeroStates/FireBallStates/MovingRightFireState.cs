using Mario.Entities.Abstract;

public class MovingRightFireState : AbstractEntityState
{
    public MovingRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunFireMario");
    }
}