using Mario.Entities.Abstract;

public class StandingRightFireState : AbstractEntityState
{
    public StandingRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightStandFireMario");
    }
}