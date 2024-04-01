using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class CoinState : AbstractEntityState
{
    public CoinState() : base()
    {
        sprite = spriteFactory.CreateSprite("coin");
    }
}
