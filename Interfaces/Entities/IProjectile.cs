using System;
using Mario.Interfaces;

namespace GreenGame.Interfaces.Entities
{
	public interface IProjectile : ISprite
	{
		public void DeleteProjectile();
	}
}
