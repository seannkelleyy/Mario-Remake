using Mario.Entities.Blocks.BlockStates;
using Mario.Entities.Items;
using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class CoinBlock : AbstractBlock
    {
        private IItem coin;

        public CoinBlock(Vector2 position, bool breakable, bool collidable, string item)
        {
            this.position = position;
            coin = new Coin(position);
            currentState = new GoldenBlockState();
            isCollidable = collidable;
            isBreakable = breakable;
        }

        // Give out a coin until out of coins. Then turn into hard block
        public override void GetHit()
        {
            currentState = new HardBlockState();
            coin.MakeVisable();
        }
    }
}
