﻿using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.EnemyCycle
{
    public class EnemyCycle : IEnemyCycle
    {
        private ISprite[] Enemies;
        private ISprite currentSprite;
        private int indexOfCurrentSprite = 0;
        private Vector2 position;

        public EnemyCycle(ISprite[] enemies)
        {
            Enemies = enemies;
            currentSprite = enemies[indexOfCurrentSprite];
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            this.position = position;
            currentSprite.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentSprite.Update(gameTime);
        }

        // NOTE: These methods will go bye bye after Sprint 2.

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
