using Mario.Entities.Abstract;

public class StandingLeftFireState : AbstractEntityState
{
    public StandingLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftStandFireMario");
    }
}