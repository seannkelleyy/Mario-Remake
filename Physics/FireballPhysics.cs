using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            if (!isFalling) UpdateHorizontal();
            else UpdateVertical();
        }

        internal override void UpdateHorizontal()
        {

        }

        internal override void UpdateVertical()
        {
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
