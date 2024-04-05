using Mario.Entities.Abstract;

namespace Mario.Entities.Items.ItemStates;

public class UndergroundCoinState : AbstractEntityState
{
    public UndergroundCoinState() : base()
    {
        sprite = spriteFactory.CreateSprite("coinUnderground");
    }
}
