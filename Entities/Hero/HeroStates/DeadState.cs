using Mario.Entities.Character.HeroStates;

public class DeadState : HeroState
{
    public DeadState() : base()
    {
        sprite= spriteFactory.CreateSprite("deadMario");
    }
}