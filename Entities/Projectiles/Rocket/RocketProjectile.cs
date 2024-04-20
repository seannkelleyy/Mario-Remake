using Mario.Collisions;
using Mario.Interfaces.Entities.Projectiles;
using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Projectiles.Rocket
{
    public class RocketProjectile : AbstractCollideable, IProjectile
    {
        private bool isExploded;

        private ProjectilePhysics physics { get; }
        public bool teamMario { get; }
        public RocketProjectile(Vector2 position, HorizontalDirection currentHorizontalDirection, bool teamMario, float angle = 0)
        {
            if (currentHorizontalDirection == HorizontalDirection.left)
            {
                currentState = new LeftRocketState(this);

            }
            else
            {
                currentState = new RightRocketState(this);
            }
            this.position = position;
            physics = new ProjectilePhysics(this, currentHorizontalDirection, angle);
            this.teamMario = teamMario;
            isExploded = false;
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
                SetPosition(new Vector2(this.GetPosition().X + (this.GetRectangle().Width / 2) - new RocketExplosionState(this).GetVector().X, this.GetPosition().Y + (this.GetRectangle().Height / 2) - new RocketExplosionState(this).GetVector().Y));
                currentState = new RocketExplosionState(this);
            }
        }
        public ProjectilePhysics GetPhysics()
        {
            return physics;
        }
        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
