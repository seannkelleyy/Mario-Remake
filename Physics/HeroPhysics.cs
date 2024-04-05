using Mario.Entities.Character;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class HeroPhysics : AbstractEntityPhysics
    {
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
        public void WalkRight()
        {
            currentHorizontalDirection = horizontalDirection.right;
            if (!entity.GetCollisionState(CollisionDirection.Right))
            {
                if (velocity.X < PhysicsSettings.maxRunSpeed)
                {
                    velocity.X += PhysicsSettings.runAcceleration;
                }
            }
        }

        public void WalkLeft()
        {
            currentHorizontalDirection = horizontalDirection.left;
            if (!entity.GetCollisionState(CollisionDirection.Left))
            {
                if (velocity.X > -PhysicsSettings.maxRunSpeed)
                {
                    velocity.X -= PhysicsSettings.runAcceleration;
                }
            }
        }

        internal override void UpdateHorizontal()
        {
            // If the player is not pressing any keys, apply friction
            if (velocity.X > 0)
            {
                velocity.X -= PhysicsSettings.friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += PhysicsSettings.friction;
            }

            if (Math.Abs(velocity.X) < PhysicsSettings.friction)
            {
                velocity.X = 0;
                ((Hero)entity).Stand();
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        #endregion

        #region vertical movement

        public void Jump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsSettings.jumpForce;
                jumpCounter = 1;
            }
        }

        public void SmallJump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsSettings.jumpForce;
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
                ((Hero)entity).Stand();
                smallJumpCounter = 0;
                jumpCounter = 0;
                StopVertical();
            }
        }

        private void HandleUpwardMovement()
        {
            if (entity.GetCollisionState(CollisionDirection.Top) || isMininumJump && jumpCounter >= PhysicsSettings.minimumJumpLimit)
            {
                jumpCounter = PhysicsSettings.regularJumpLimit;
                smallJumpCounter = PhysicsSettings.smallJumpLimit;
                isFalling = true;
                isMininumJump = false;
                isDecelerating = true;
            }
            else if (smallJumpCounter > 0 && smallJumpCounter < PhysicsSettings.smallJumpLimit && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsSettings.jumpForce * (1 - smallJumpCounter / PhysicsSettings.smallJumpLimit);
                smallJumpCounter++;
            }
            else if (jumpCounter < PhysicsSettings.regularJumpLimit && jumpCounter > 0 && !entity.GetCollisionState(CollisionDirection.Top))
            {
                velocity.Y = -PhysicsSettings.jumpForce * (1 - jumpCounter / PhysicsSettings.regularJumpLimit);
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
                velocity.Y += PhysicsSettings.decelerationFactor;
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

        #endregion
    }
}
