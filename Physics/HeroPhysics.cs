using Mario.Entities.Character;
using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
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
            currentHorizontalDirection = HorizontalDirection.right;
            if (!entity.GetCollisionState(CollisionDirection.Right))
            {
                if (velocity.X < PhysicsSettings.MaxRunSpeed)
                {
                    velocity.X += PhysicsSettings.RunAcceleration;
                }
            }
        }

        public void WalkLeft()
        {
            currentHorizontalDirection = HorizontalDirection.left;
            if (!entity.GetCollisionState(CollisionDirection.Left))
            {
                if (velocity.X > -PhysicsSettings.MaxRunSpeed)
                {
                    velocity.X -= PhysicsSettings.RunAcceleration;
                }
            }
        }

        internal override void UpdateHorizontal()
        {
            // If the player is not pressing any keys, apply friction
            if (velocity.X > 0)
            {
                velocity.X -= PhysicsSettings.Friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += PhysicsSettings.Friction;
            }

            if (Math.Abs(velocity.X) < PhysicsSettings.Friction)
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
                velocity.Y = -PhysicsSettings.JumpForce;
                jumpCounter = 1;
            }
        }

        public void SmallJump()
        {
            if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsSettings.JumpForce;
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

        #endregion
    }
}
