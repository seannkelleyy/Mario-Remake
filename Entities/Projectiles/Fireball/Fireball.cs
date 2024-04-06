using Mario.Collisions;
using Mario.Interfaces.Entities.Projectiles;
using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Projectiles
{
    public class Fireball : AbstractCollideable, IProjectile
    {
        private FireballPhysics physics { get; }
        private bool isExploded = false;
        public Fireball(Vector2 position, HorizontalDirection currentHorizontalDirection)
        {
            currentState = new FireballMovingState(this);
            this.position = position;
            physics = new FireballPhysics(this, currentHorizontalDirection);
        }

        public override void Update(GameTime gameTime)
        {
            CollisionManager.Instance.Run(this);
            currentState.Update(gameTime);
            ClearCollisions();
        }
        public void Destroy()
        {
            if (!isExploded)
            {
                isExploded = true;
                currentState = new FireballExplosionState(this);
            }
        }
        public FireballPhysics GetPhysics()
        {
            return physics;
        }
        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
