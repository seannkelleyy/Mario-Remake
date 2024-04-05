using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Projectiles
{
    public class Fireball : AbstractCollideable, IFireball
    {
        public FireballPhysics physics { get; }
        public Fireball(Vector2 position, horizontalDirection currentHorizontalDirection)
        {
            currentState = new FireballMovingState(this);
            this.position = position;
            physics = new FireballPhysics(this, currentHorizontalDirection);
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            ClearCollisions();
        }
        public FireballPhysics GetPhysics()
        {
            return physics;
        }
    }
}
