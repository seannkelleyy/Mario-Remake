using Mario.Collisions;
using Mario.Entities.Projectiles.Bullet;
using Mario.Interfaces.Entities.Projectiles;
using Mario.Physics;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Projectiles
{
    public class BulletObject : AbstractCollideable, IProjectile
    {
        private float elapsedSeconds = 0;
        private ProjectilePhysics physics { get; }
        public bool teamMario { get; }
        public BulletObject(Vector2 position, HorizontalDirection currentHorizontalDirection, bool teamMario, float angle = 0)
        {
            currentState = new BulletState();
            this.position = position;
            physics = new ProjectilePhysics(this, currentHorizontalDirection, angle);
            this.teamMario = teamMario;
        }

        public override void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= EntitySettings.HeroAttackTime)
            {
                GameContentManager.Instance.RemoveEntity(this);
            }
            else
            {
                CollisionManager.Instance.Run(this);
                physics.Update();
                ClearCollisions();
            }
        }
        public void Destroy()
        {
            GameContentManager.Instance.RemoveEntity(this);
        }
        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
