using System;
using Mario.Interfaces;

namespace GreenGame.Interfaces
{
	public interface IBlock : ISprite
    {
		public void Hit();
	}
}

