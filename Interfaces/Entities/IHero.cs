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

        // Function for Hero to collect an item
        void Collect(IItem item);

        // Function to power up Hero. i.e.make big, firepower...
        // Probably needs a param
        void PowerUp();

        // Function to handle when Hero takes damage
        void TakeDamage();

        // Actions
        // This will be a generic attack command. We could get what kind of attack
        // Based upon the state of the Hero.
        public void Attack(Game game);
	}
}

