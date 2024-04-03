using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;
using static Mario.Physics.AbstractEntityPhysics;

namespace Mario.Entities.Projectiles
{
    public class Fireball : AbstractCollideable, IFireball
    {
        public FireballPhysics physics { get; }
        bool exploded = false;
        public Fireball(Vector2 position, horizontalDirection currentHorizontalDirection)
        {
            currentState = new FireballMovingState();
            this.position = position;
            physics = new FireballPhysics(this, currentHorizontalDirection);
        }

        public override void Update(GameTime gameTime)
        {
            ClearCollisions();

            currentState.Update(gameTime);
            if (this.GetCollisionState(CollisionDirection.Left) || this.GetCollisionState(CollisionDirection.Right))
            {
                exploded = true;
            }
            if (!exploded)
            {
                physics.Update();
            }
        }
    }
}
