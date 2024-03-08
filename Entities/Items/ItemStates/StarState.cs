namespace Mario.Entities.Items.ItemStates;

public class StarState : ItemState
{
    public StarState() : base()
    {
        sprite = spriteFactory.CreateSprite("star");
    }
}
