using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.EnemyCycle
{
    // GONE AFTER SPRINT 2
    public class EnemyCycle : IEnemyCycle
    {
        private ISprite[] Enemies;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;
        private Vector2 position;

        public EnemyCycle(ISprite[] enemies, Vector2 position)
        {
            Enemies = enemies;
            currentSprite = enemies[indexOfCurrentSprite];
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
        }

        // Changes the current sprite to be drawn to the next enemy in the list
        public void CycleEnemyNext()
        {
            if (indexOfCurrentSprite == Enemies.Length - 1)
            {
                indexOfCurrentSprite = 0;
            }
            else
            {
                indexOfCurrentSprite++;
            }
            currentSprite = Enemies[indexOfCurrentSprite];
        }

        // Changes the current sprite to be drawn to the previous enemy in the list
        public void CycleEnemyPrev()
        {
            if (indexOfCurrentSprite == 0)
            {
                indexOfCurrentSprite = Enemies.Length - 1;
            }
            else
            {
                indexOfCurrentSprite--;
            }
            currentSprite = Enemies[indexOfCurrentSprite];
        }
    }
}
