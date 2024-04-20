using Mario.Entities.Abstract;

public class RightFacingFireBroState : AbstractEntityState
{
    public RightFacingFireBroState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightAttackFireBro");
    }
}
