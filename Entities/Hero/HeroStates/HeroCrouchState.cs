using Mario.Entities.Character.HeroStates;

public class CrouchState : HeroState
{
    public CrouchState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightCrouchFireMario");
    }
}