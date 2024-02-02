using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IEnemy : ISprite
    {
        // Movement
        public void WalkLeft();

        public void WalkRight();

        public void Jump();

        // Function to handle when Enemu takes damage
        void TakeDamage();

        // Actions
        // This will be a generic attack command. We could get what kind of attack
        // Based upon the state of the Enemy.
        public void Attack(Game game);
    }
}

