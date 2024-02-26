using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Entities.Blocks.BlockStates;

namespace Mario.Entities.Blocks
{
    public class CoinBlock : IBlock
    {
        private BlockState currentState;
        private Vector2 position;
        private int coinCount;
        private IItem coin;

        public CoinBlock(Vector2 position, int coinCount)
        {
            this.position = position;
            currentState = new GoldenBlockState();
            this.coinCount = coinCount;
            coin = new Coin();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        // Give out a coin until out of coins. Then turn into hard block
        public void GetHit()
        {
            if (coinCount == 0)
            {
                currentState = new HardBlockState();
            } 
            else
            {
                // Replace method with something like coin.Appear()
                coin.Draw(position + 16);
            }
        }
    }
}
