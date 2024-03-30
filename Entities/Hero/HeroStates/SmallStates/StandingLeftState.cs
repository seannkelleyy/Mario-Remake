using Mario.Entities.Abstract;

public class StandingLeftState : AbstractEntityState
{
    public StandingLeftState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandMario");
    }
}