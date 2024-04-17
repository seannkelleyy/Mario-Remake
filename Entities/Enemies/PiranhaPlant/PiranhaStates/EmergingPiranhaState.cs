using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;
using Microsoft.Xna.Framework;

public class EmergingPiranhaState : AbstractEntityState
{
    public EmergingPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("emergingPiranha");
    }

    
}