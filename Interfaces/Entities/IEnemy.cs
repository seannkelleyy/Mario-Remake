using Mario.Interfaces;

namespace Mario.Interfaces
{
	public interface IEnemy : ISprite
    {
        // Movement
        public void ChangeDirection();

        // Function to handle when Enemu takes damage
        void TakeDamage();
    }
}

