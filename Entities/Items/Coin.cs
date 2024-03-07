using Mario.Entities.Items.ItemStates;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class Coin : AbstractItem
    {
        public Coin(Vector2 position)
        {
            this.position = position;
            currentState = new CoinState();
        }

        public override void MakeVisable()
        {
            IsVisable = true;
        }
    }
}
