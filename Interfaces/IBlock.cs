using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IBlock : ISprite
    {
		public void Hit(Game game);
	}
}

