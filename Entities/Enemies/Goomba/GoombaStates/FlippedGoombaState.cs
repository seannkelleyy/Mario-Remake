using Mario.Entities.Abstract;

public class FlippedGoombaState : AbstractEntityState
{
    public FlippedGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("flippedGoomba");
    }
}