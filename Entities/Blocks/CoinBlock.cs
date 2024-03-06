using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class CoinBlock : AbstractBlock
    {
        private int coinCount;
        private IItem[] coins;
        public bool isCollidable { get; } = true;
        public bool isBreakable { get; } = false;

        public CoinBlock(Vector2 position, int coinAmount)
        {
            this.position = position;
            currentState = new GoldenBlockState();
            coinCount = coinAmount;

            // Give the block the coins
            GameObjectFactory gameObjectFactory = GameObjectFactory.Instance;
            coins = new IItem[coinAmount];
            for (int i = 0; i < coinAmount; i++)
            {
                coins[i] = gameObjectFactory.CreateCoin(position);
            }
        }

        // Give out a coin until out of coins. Then turn into hard block
        public override void GetHit()
        {
            if (coinCount == 0)
            {
                currentState = new HardBlockState();
            }
            else
            {
                coinCount--;
                coins[coinCount].MakeVisable();
            }
        }
    }
}
