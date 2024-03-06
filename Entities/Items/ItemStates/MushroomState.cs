namespace Mario.Entities.Items.ItemStates;

public class MushroomState : ItemState
{
    public MushroomState() : base()
    {
        sprite = spriteFactory.CreateSprite("mushroom");
    }
}
