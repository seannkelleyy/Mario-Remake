using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity, horizontalDirection currentHorizontalDirection) : base(entity)
        {
            if (currentHorizontalDirection == horizontalDirection.left)
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(0, 16));
                velocity = new Vector2(-6.25f, 0);
            }
            else
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(16, 16));
                velocity = new Vector2(6.25f, 0);
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
                velocity.Y = -3.75f;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y += .9375f;
        }

        public override void WalkLeft()
        {
            Logger.Instance.LogInformation("Walk left not implemented in Projectile Physics");
        }

        public override void WalkRight()
        {
            Logger.Instance.LogInformation("Walk right not implemented in Projectile Physics");

        }

        public override void Jump()
        {
            Logger.Instance.LogInformation("Jump not implemented in Projectile Physics");

        }

        public override void SmallJump()
        {
            Logger.Instance.LogInformation("Small Jump left not implemented in Projectile Physics");

        }
    }
}
