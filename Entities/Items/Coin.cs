using Mario.Entities.Items.ItemStates;
using Mario.Global;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class Coin : AbstractItem
    {
        public Coin(Vector2 position, bool isUnderground = false)
        {
            this.position = position;
            if (isUnderground)
            {
                currentState = new UndergroundCoinState();
            }
            else
            {
                currentState = new CoinState();
            }
        }

        public override void MakeVisible()
        {
            position.Y -= GlobalVariables.blockHeightWidth;
            isVisible = true;
        }

        public override void ChangeDirection()
        {
            Logger.Instance.LogInformation("ChangeDirection not implemented in Coin");
        }
        public override Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }
    }
}
