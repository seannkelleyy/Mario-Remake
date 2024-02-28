using Mario.Entities.Enemy.Koopa.KoopaStates;

public class RightMovingKoopaState : KoopaState
{
    public RightMovingKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("rightKoopa");
    }
}