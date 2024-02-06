using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IEnemy : ISprite
    {
        // Movement
        public void ChangeDirection();

        // Function to handle when Enemu takes damage
        void TakeDamage();
    }
}

