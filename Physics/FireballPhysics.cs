using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity, bool isRight) : base(entity)
        {
            if (isRight)
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(blockHeightWidth, blockHeightWidth));
                velocity = new Vector2(PhysicsSettings.fireballHorizontalSpeed, 0);
            }
            else
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(0, blockHeightWidth));
                velocity = new Vector2(-PhysicsSettings.fireballHorizontalSpeed, 0);
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
                velocity.Y = -PhysicsSettings.fireballBounceForce;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y += PhysicsSettings.fireballVerticalSpeed;
        }
    }
}
