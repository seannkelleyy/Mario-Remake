using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Interfaces
{
	public interface IItem : ISprite
	{
		public Rectangle GetRectangle();

		public void DeleteItem();
	}
}

