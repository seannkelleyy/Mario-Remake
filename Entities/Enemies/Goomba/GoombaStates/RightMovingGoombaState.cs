using Mario.Entities.Abstract;

public class RightMovingGoombaState : AbstractEntityState
{
    public RightMovingGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("goomba");
    }
}