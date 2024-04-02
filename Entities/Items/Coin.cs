using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class Coin : AbstractItem
    {
        public Coin(Vector2 position, bool isUnderground = false)
        {
            this.position = position;
            if (isUnderground) {
                currentState = new UndergroundCoinState();
            } else
            {
                currentState = new CoinState();
            }
        }

        public override void MakeVisible()
        {
            position.Y -= 16;
            isVisible = true;
        }
    }
}
