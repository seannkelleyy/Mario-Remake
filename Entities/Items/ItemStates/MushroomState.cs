using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class MushroomState : AbstractEntityState
{
    public MushroomState() : base()
    {
        sprite = spriteFactory.CreateSprite("mushroom");
    }
}
