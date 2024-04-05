﻿using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public class StarPhysics : AbstractEntityPhysics
    {
        public StarPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
            isFalling = false;
        }

        public override void Update()
        {
            UpdateVertical();
            UpdateHorizontal();
        }

        internal override void UpdateHorizontal()
        {
            if (currentHorizontalDirection == horizontalDirection.right && !entity.GetCollisionState(CollisionDirection.Right))
            {
                velocity.X = PhysicsSettings.enemySpeed;
            }
            else if (currentHorizontalDirection == horizontalDirection.left && !entity.GetCollisionState(CollisionDirection.Left))
            {
                velocity.X = -PhysicsSettings.enemySpeed;
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
        }

        internal override void UpdateVertical()
        {
            if (isFalling)
            {
                HandleDownwardMovement();
            }
            else
            {
                if (jumpCounter == 0)
                {
                    Jump();
                }
                else
                {
                    HandleUpwardMovement();
                }
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



        public void Jump()
        {
            isFalling = false;
            velocity.Y = -PhysicsSettings.jumpForce;
            jumpCounter = 1;
        }

        private void HandleUpwardMovement()
        {
            if (entity.GetCollisionState(CollisionDirection.Top) || isMininumJump && jumpCounter >= PhysicsSettings.minimumJumpLimit)
            {
                jumpCounter = PhysicsSettings.regularJumpLimit;
                isFalling = true;
                isMininumJump = false;
                isDecelerating = true;
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

        private void HandleDownwardMovement()
        {
            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y += ApplyGravity();
            }
            else
            {
                jumpCounter = 0;
                StopVertical();
                isFalling = false;
            }
        }
    }
}