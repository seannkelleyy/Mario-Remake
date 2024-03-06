namespace Mario.Entities.Items.ItemStates;

public class CoinState : ItemState
{
    public CoinState() : base()
    {
        sprite = spriteFactory.CreateSprite("coin");
    }
}
