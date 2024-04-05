using Mario.Interfaces.Base;
using Mario.Interfaces.Entities.Projectiles;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity, horizontalDirection currentHorizontalDirection) : base(entity)
        {
            if (currentHorizontalDirection == horizontalDirection.left)
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(0, blockHeightWidth));
                velocity = new Vector2(-PhysicsSettings.fireballHorizontalSpeed, 0);
            }
            else
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(blockHeightWidth, blockHeightWidth));
                velocity = new Vector2(PhysicsSettings.fireballHorizontalSpeed, 0);
            }
            this.entity = entity;
        }

        public override void Update()
        {
            UpdateHorizontal();
            UpdateVertical();
        }

        internal override void UpdateHorizontal()
        {
            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        internal override void UpdateVertical()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                if (!isFalling)
                {
                    ((IProjectile)entity).Destroy();
                }
                else
                {
                    velocity.Y = -PhysicsSettings.fireballBounceForce;
                    isFalling = false;
                }
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            if (velocity.Y < PhysicsSettings.fireballBounceForce)
            {
                velocity.Y += PhysicsSettings.fireballVerticalAcceleration;
            }
            if (velocity.Y > 0)
            {
                isFalling = true;
            }
        }
    }
}
