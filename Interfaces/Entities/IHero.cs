using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IHero : ISprite
    {
		// Movement
		public void WalkLeft();

		public void WalkRight();

		public void Jump();

		// Only for 'big' hereos. Implementation could change with state.
		public void Crouch();

		// Actions
		// This will be a generic attack command. We could get what kind of attack
		// Based upon the state of the Hero.
		public void Attack(Game game);
	}
}

