using Mario.Entities.Abstract;

public class StompedGoombaState : AbstractEntityState
{
    public StompedGoombaState() : base()
    {
        sprite = spriteFactory.CreateSprite("stompedGoomba");
    }

}