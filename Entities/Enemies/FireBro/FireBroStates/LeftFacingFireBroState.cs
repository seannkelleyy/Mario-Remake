using Mario.Entities.Abstract;

public class LeftFacingFireBroState : AbstractEntityState
{
    public LeftFacingFireBroState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftAttackFireBro");
    }
}
