using Mario.Entities.Character;
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

        public void Jump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsSettings.JumpForce;
                jumpCounter = 1;
            }
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

        private void HandleDownwardMovement()
        {
            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y += ApplyGravity();
            }
            else
            {
                smallJumpCounter = 0;
                jumpCounter = 0;
                StopVertical();
            }
        }

        private void HandleUpwardMovement()
        {
            if (entity.GetCollisionState(CollisionDirection.Top) || isMininumJump && jumpCounter >= PhysicsSettings.MinimumJumpLimit)
            {
                jumpCounter = PhysicsSettings.RegularJumpLimit;
                smallJumpCounter = PhysicsSettings.SmallJumpLimit;
                isFalling = true;
                isMininumJump = false;
                isDecelerating = true;
            }
            else if (smallJumpCounter > 0 && smallJumpCounter < PhysicsSettings.SmallJumpLimit && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsSettings.JumpForce * (1 - smallJumpCounter / PhysicsSettings.SmallJumpLimit);
                smallJumpCounter++;
            }
            else if (jumpCounter > 0 && jumpCounter < PhysicsSettings.RegularJumpLimit && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsSettings.JumpForce * (1 - jumpCounter / PhysicsSettings.RegularJumpLimit);
                jumpCounter++;
            }
            else
            {
                isFalling = true;
            }
        }

        internal override void UpdateVertical()
        {
            if (isFalling)
            {
                HandleDownwardMovement();
            }
            else
            {
                HandleUpwardMovement();
            }

            if (isDecelerating)
            {
                velocity.Y += PhysicsSettings.DecelerationFactor;
                if (velocity.Y >= 0)
                {
                    // Once upward velocity reaches 0, start falling and stop decelerating
                    velocity.Y = 0;
                    isFalling = true;
                    isDecelerating = false;
                }
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            StopVertical();
        }
    }
}
