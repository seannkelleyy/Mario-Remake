using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class OneUpState : AbstractEntityState
{
    public OneUpState() : base()
    {
        sprite = spriteFactory.CreateSprite("oneUp");
    }
}
