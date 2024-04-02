using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Projectiles
{
    public class Fireball : AbstractCollideable, IFireball
    {
        bool exploded = false;
        public Fireball(Vector2 position)
        {
            currentState = new FireballMovingState();
            this.position = position;
            physics = new FireballPhysics(this);
        }

        public override void Update(GameTime gameTime)
        {
            ClearCollisions();

            currentState.Update(gameTime);
        }

        public void Bounce()
        {
        }
        public void Explode()
        {
            if (!exploded)
            {
                currentState = new FireballExplosionState();
                exploded = true;
            }
        }
    }
}
