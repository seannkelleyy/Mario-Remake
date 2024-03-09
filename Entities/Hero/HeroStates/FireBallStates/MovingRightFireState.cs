using Mario.Entities.Character.HeroStates;

public class MovingRightFireState : HeroState
{
    public MovingRightFireState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightRunFireMario");
    }
}