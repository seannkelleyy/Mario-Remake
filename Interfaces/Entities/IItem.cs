using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces
{
	public interface IItem
	{
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        // Cycles through to next sprite when moving
        public void CycleItemNext();
		public void CycleItemPrev();
	}
}

