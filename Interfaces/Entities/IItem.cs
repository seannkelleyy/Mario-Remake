using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IItem : ISprite
	{
        public void DeleteItem(Game game);
	}
}

