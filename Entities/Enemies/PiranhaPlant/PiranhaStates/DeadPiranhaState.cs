using Mario.Entities.Abstract;
using Mario.Entities.Sprites;
using Mario.Sprites;
using Microsoft.Xna.Framework;

public class DeadPiranhaState : AbstractEntityState
{
    public DeadPiranhaState() : base()
    {
        sprite = spriteFactory.CreateSprite("deadPiranha");
    }


}