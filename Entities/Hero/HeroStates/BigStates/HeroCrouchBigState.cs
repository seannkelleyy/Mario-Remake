using Mario.Entities.Character.HeroStates;

public class CrouchBigState : HeroState
{
    public CrouchBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightCrouchBigMario");
    }
}