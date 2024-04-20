using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class ProjectilePhysics : AbstractEntityPhysics
    {
        public ProjectilePhysics(ICollideable entity, HorizontalDirection currentHorizontalDirection, float angle) : base(entity)
        {
            if (currentHorizontalDirection == HorizontalDirection.left)
            {
                velocity = new Vector2(-PhysicsSettings.FireballHorizontalSpeed * (float)Math.Cos(Math.PI * angle / 180.0), PhysicsSettings.FireballHorizontalSpeed * (float)Math.Sin(Math.PI * angle / 180.0));
            }
            else
            {
                entity.SetPosition(entity.GetPosition() + new Vector2(BlockHeightWidth, 0));
                velocity = new Vector2(PhysicsSettings.FireballHorizontalSpeed * (float)Math.Cos(Math.PI * angle / 180.0), PhysicsSettings.FireballHorizontalSpeed * (float)Math.Sin(Math.PI * angle / 180.0));
            }
            this.entity = entity;
        }

        public override void Update()
        {
            entity.SetPosition(entity.GetPosition() + velocity);
        }

        internal override void UpdateHorizontal()
        { }

        internal override void UpdateVertical()
        { }
    }
}
