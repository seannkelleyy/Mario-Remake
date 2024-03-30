using Mario.Entities.Abstract;
public class MovingRightBigState : AbstractEntityState
{
    public MovingRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunBigMario");
    }
}