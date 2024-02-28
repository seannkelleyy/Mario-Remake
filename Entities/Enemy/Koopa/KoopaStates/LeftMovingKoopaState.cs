using Mario.Entities.Enemy.Koopa.KoopaStates;

public class LeftMovingKoopaState : KoopaState
{
    public LeftMovingKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("leftKoopa");
    }
}