using System;
namespace GreenGame.Interfaces
{
	public interface IBlock
	{
		public void Update();

		public void Draw();

		public void Hit();
	}
}

