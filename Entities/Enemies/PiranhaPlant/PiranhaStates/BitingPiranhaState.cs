using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;
using Microsoft.Xna.Framework;

public class BitingPiranhaState : AbstractEntityState
{
    public BitingPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("bitingPiranha");
    }

   
}