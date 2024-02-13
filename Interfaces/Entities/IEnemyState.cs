using Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace GreenGame.Interfaces
{
	public interface IEnemyState
    {
        // Movement
        public void ChangeDirection();

        // Function to handle when Enemu takes damage
        void BeStomped();
        void BeFlipped();

        void Update(GameTime gameTime);
    }
}

