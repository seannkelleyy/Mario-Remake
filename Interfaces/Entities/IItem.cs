using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IItem : ISprite
	{
		public void CycleItem();

        public void DeleteItem(Game game);
	}
}

