using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;
using Microsoft.Xna.Framework;

public class RetractingPiranhaState : AbstractEntityState
{
    public RetractingPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("retractingPiranha");
    }

    
}