using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class EntityPhysics : AbstractEntityPhysics
    {
        private bool isStationary = false;
        public EntityPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            UpdateVertical();
            UpdateHorizontal();
        }

        public void ToggleIsStationary()
        {
            isStationary = !isStationary;
        }

        public bool IsStationary()
        {
            return isStationary;
        }

        internal override void UpdateHorizontal()
        {
            if (isStationary) return;
            if (currentHorizontalDirection == HorizontalDirection.right && !entity.GetCollisionState(CollisionDirection.Right))
            {
                if (entity is Koopa koopa && koopa.isShell)
                {
                    velocity.X = PhysicsSettings.KoopaShellSpeed;
                }
                else
                {
                    velocity.X = PhysicsSettings.EnemySpeed;
                }
            }
            else if (currentHorizontalDirection == HorizontalDirection.left && !entity.GetCollisionState(CollisionDirection.Left))
            {
                if (entity is Koopa koopa && koopa.isShell)
                {
                    velocity.X = -PhysicsSettings.KoopaShellSpeed;
                }
                else
                {
                    velocity.X = -PhysicsSettings.EnemySpeed;
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
