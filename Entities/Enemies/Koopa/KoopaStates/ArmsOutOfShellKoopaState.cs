using Mario.Entities.Abstract;

public class ArmsOutOfShellKoopaState : AbstractEntityState
{
    public ArmsOutOfShellKoopaState() : base()
    {
        sprite = spriteFactory.CreateSprite("shellLegsKoopa");
    }
}