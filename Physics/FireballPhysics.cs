using Mario.Interfaces.Base;
using Mario.Interfaces.Entities.Projectiles;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity, HorizontalDirection currentHorizontalDirection) : base(entity)
        {
            if (currentHorizontalDirection == HorizontalDirection.left)
            {
                velocity = new Vector2(-PhysicsSettings.FireballHorizontalSpeed, 0);
            }
            else
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(BlockHeightWidth, 0));
                velocity = new Vector2(PhysicsSettings.FireballHorizontalSpeed, 0);
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
                    velocity.Y = -PhysicsSettings.FireballBounceForce;
                    isFalling = false;
                }
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            if (velocity.Y < PhysicsSettings.FireballBounceForce)
            {
                velocity.Y += PhysicsSettings.FireballVerticalAcceleration;
            }
            if (velocity.Y > 0)
            {
                isFalling = true;
            }
        }
    }
}
