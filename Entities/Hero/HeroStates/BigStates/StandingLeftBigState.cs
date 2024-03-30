using Mario.Entities.Abstract;

public class StandingLeftBigState : AbstractEntityState
{
    public StandingLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandBigMario");
    }
}