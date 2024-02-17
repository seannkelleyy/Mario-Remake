using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy
    {
        // Movement
        public void ChangeDirection();

        // Function to handle when Enemu takes damage
        public void Stomp();
        public void Flip();

        public void Update(GameTime gameTime);

        public void Draw();
    }
}
