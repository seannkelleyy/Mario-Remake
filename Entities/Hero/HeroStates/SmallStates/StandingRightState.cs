using Mario.Entities.Abstract;

public class StandingRightState : AbstractEntityState
{
    public StandingRightState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandMario");
    }
}