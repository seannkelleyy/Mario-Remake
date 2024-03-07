namespace Mario.Entities.Items.ItemStates;

public class FireFlowerState : ItemState
{
    public FireFlowerState() : base()
    {
        sprite = spriteFactory.CreateSprite("fireFlower");
    }
}
