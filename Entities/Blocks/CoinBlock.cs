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
            coins = new IItem[coinAmount];
            for (int i = 0; i < coinAmount; i++)
            {
                // TODO: This instantiation will be changed once items are implemented and can be constructed properly
                coins[i] = (IItem)GameObjectFactory.Instance.CreateEntity("coin", position);
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
                // coins[coinCount].MakeVisable(); // NOTE: MakeVisable will make the item appear above the block. It's not implemented yet
            }
        }
    }
}
