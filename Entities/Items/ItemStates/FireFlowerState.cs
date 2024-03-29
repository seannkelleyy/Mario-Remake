using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class FireFlowerState : AbstractEntityState
{
    public FireFlowerState() : base()
    {
        sprite = spriteFactory.CreateSprite("fireFlower");
    }
}
