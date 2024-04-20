using Mario.Entities.Abstract;

public class StompedFireBroState : AbstractEntityState
{
    public StompedFireBroState() : base()
    {
        sprite = spriteFactory.CreateSprite("shellFireBro");
    }
}
