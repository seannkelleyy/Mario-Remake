using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces
{
    // This interface is just here for Sprint2, it will be deleted after
    public interface IEnemyCycle
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

        public void CycleEnemyNext();

        public void CycleEnemyPrev();

    }
}

