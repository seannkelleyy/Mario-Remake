using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;

public class HiddenPiranhaState : AbstractEntityState
{
    public HiddenPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("hiddenPiranha");  
}