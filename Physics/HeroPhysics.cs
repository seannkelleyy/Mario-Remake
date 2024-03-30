using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class HeroPhysics : AbstractEntityPhysics
    {
        private float jumpCounter = 0;
        private float smallJumpCounter = 0;

        public HeroPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            UpdateHorizontal();
            UpdateVertical();
        }

        #region horizontal movement
        public override void WalkRight()
        {
            isRight = true;
            if (!entity.GetCollisionState(CollisionDirection.Right))
            {
                if (velocity.X < PhysicsVariables.maxRunSpeed)
                {
                    velocity.X += PhysicsVariables.runAcceleration;
                }
            }
        }

        public override void WalkLeft()
        {
            isRight = false;
            if (!entity.GetCollisionState(CollisionDirection.Left))
            {
                if (velocity.X > -PhysicsVariables.maxRunSpeed)
                {
                    velocity.X -= PhysicsVariables.runAcceleration;
                }
            }
        }

        internal override void UpdateHorizontal()
        {
            // If the player is not pressing any keys, apply friction
            if (isRight && velocity.X > 0)
            {
                velocity.X -= PhysicsVariables.friction;
            }
            else if (!isRight && velocity.X < 0)
            {
                velocity.X += PhysicsVariables.friction;
            }

            if (Math.Abs(velocity.X) < PhysicsVariables.friction)
            {
                velocity.X = 0;
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        #endregion

        #region vertical movement

        public override void Jump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsVariables.jumpForce;
                jumpCounter = 1;
            }
        }

        public override void SmallJump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsVariables.jumpForce;
                smallJumpCounter = 1;
            }
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
            if (smallJumpCounter > 0 && smallJumpCounter < PhysicsVariables.smallJumpLimit && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsVariables.jumpForce * (1 - smallJumpCounter / PhysicsVariables.smallJumpLimit);
                smallJumpCounter++;
            }
            else if (jumpCounter < PhysicsVariables.regularJumpLimit && jumpCounter > 0 && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsVariables.jumpForce * (1 - jumpCounter / PhysicsVariables.regularJumpLimit);
                jumpCounter++;
            }
            else if (entity.GetCollisionState(CollisionDirection.Top))
            {
                StopVertical();
                jumpCounter = PhysicsVariables.regularJumpLimit;
                smallJumpCounter = PhysicsVariables.smallJumpLimit;
                isFalling = true;
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
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            StopVertical();
        }

        #endregion
    }
}
