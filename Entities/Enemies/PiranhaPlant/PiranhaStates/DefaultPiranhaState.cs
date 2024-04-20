using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;

public class DefaultPiranhaState : AbstractEntityState
{
    public DefaultPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("defaultPiranha");
    }
}