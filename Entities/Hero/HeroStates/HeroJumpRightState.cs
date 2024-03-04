using Mario.Entities.Character.HeroStates;

public class JumpStateRight : HeroState
{
    public JumpStateRight() : base()
    {
        sprite = spriteFactory.CreateSprite("rightJumpFireMario");
    }
}