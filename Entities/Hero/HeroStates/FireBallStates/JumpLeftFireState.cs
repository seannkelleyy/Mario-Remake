using Mario.Entities.Character.HeroStates;

public class JumpLeftFireState : HeroState
{
    public JumpLeftFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftJumpFireMario");
    }
}