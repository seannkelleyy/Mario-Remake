using Mario.Entities.Abstract;

public class MovingGoombaState : AbstractEntityState
{
    public MovingGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("goomba");
    }
}