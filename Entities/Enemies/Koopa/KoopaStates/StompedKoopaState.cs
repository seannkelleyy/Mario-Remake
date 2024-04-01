using Mario.Entities.Abstract;

public class StompedKoopaState : AbstractEntityState
{
    public StompedKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("shellKoopa");
    }
}