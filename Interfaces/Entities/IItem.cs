using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IItem : ISprite
	{
		// Cycles through to next sprite when moving
		public void CycleItemNext();

		public void CycleItemPrev();

        public void DeleteItem(Game game);
	}
}

