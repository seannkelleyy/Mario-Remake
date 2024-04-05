using Mario.Entities.Abstract;

public class FlippedKoopaState : AbstractEntityState
{
    public FlippedKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("shellKoopa");
    }
}