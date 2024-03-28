using Mario.Entities.Abstract;

public class StandingRightBigState : AbstractEntityState
{
    public StandingRightBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandBigMario");
    }
}