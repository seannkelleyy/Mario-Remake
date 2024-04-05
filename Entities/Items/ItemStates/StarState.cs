using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class StarState : AbstractEntityState
{
    public StarState() : base()
    {
        sprite = spriteFactory.CreateSprite("star");
    }
}
