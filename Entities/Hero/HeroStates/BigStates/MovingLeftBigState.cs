using Mario.Entities.Character.HeroStates;

public class MovingLeftBigState : HeroState
{
    public MovingLeftBigState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftRunBigMario");
    }
}