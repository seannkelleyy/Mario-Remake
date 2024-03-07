using Mario.Entities.Character.HeroStates;

public class CrouchFireState : HeroState
{
    public CrouchFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightCrouchFireMario");
    }
}