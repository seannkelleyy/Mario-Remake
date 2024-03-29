using Mario.Entities.Abstract;

public class DeadState : AbstractEntityState
{
    public DeadState() : base()
    {
        sprite= spriteFactory.CreateSprite("deadMario");
    }
}