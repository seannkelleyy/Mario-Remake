using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

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
            if (isRight && !entity.GetCollisionState(CollisionDirection.Right))
            {
                if (entity is Koopa koopa && koopa.isShell)
                {
                    velocity.X = 2 * PhysicsVariables.enemySpeed;
                }
                else
                {
                    velocity.X = PhysicsVariables.enemySpeed;
                }
            }
            else if (!isRight && !entity.GetCollisionState(CollisionDirection.Left))
            {
                if (entity is Koopa koopa && koopa.isShell)
                {
                    velocity.X = -2 * PhysicsVariables.enemySpeed;
                }
                else
                {
                    velocity.X = -PhysicsVariables.enemySpeed;
                }
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        internal override void UpdateVertical()
        {

            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = true;
                velocity.Y += ApplyGravity();
            }
            else if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y = 0;
                isFalling = false;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }
    }
}
