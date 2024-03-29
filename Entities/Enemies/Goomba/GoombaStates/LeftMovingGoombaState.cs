using Mario.Entities.Abstract;

public class LeftMovingGoombaState : AbstractEntityState
{
    public LeftMovingGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("goomba");
    }
}