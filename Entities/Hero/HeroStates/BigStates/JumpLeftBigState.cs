using Mario.Entities.Character.HeroStates;

public class JumpLeftBigState : HeroState
{
    public JumpLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpBigMario");
    }
}