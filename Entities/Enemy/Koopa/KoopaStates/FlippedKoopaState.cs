using Mario.Entities.Enemy.Koopa.KoopaStates;

public class FlippedKoopaState : KoopaState
{
    public FlippedKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("flippedKoopa");
    }
}