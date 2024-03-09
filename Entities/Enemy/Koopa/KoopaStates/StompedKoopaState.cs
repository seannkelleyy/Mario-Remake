using Mario.Entities.Enemy.Koopa.KoopaStates;

public class StompedKoopaState : KoopaState
{
    public StompedKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("shellLegsKoopa");
    }
}