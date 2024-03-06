namespace Mario.Entities.Items.ItemStates;

public class OneUpState : ItemState
{
    public OneUpState() : base()
    {
        sprite = spriteFactory.CreateSprite("1up");
    }
}
