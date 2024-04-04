using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public abstract class AbstractEntityPhysics
    {

        public Vector2 velocity;
        public horizontalDirection currentHorizontalDirection = horizontalDirection.right;
        public bool isFalling = true;
        public bool isMininumJump = false;
        public bool isDecelerating = false;
        public float jumpCounter = 0;
        public float smallJumpCounter = 0;
        public ICollideable entity;

        public AbstractEntityPhysics(ICollideable entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public abstract void Update();

        internal abstract void UpdateHorizontal();

        internal abstract void UpdateVertical();

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public horizontalDirection GetHorizontalDirection()
        {
            return currentHorizontalDirection;
        }

        public void setHorizontalDirection(horizontalDirection currentHorizontalDirection)
        {
            this.currentHorizontalDirection = currentHorizontalDirection;
        }

        public float ApplyGravity()
        {
            if (velocity.Y < Math.Abs(PhysicsSettings.maxVerticalSpeed))
            {
                velocity.Y += PhysicsSettings.gravity;
            }
            else
            {
                velocity.Y = PhysicsSettings.maxVerticalSpeed;
            }
            return velocity.Y;
        }

        public float ApplyFriction()
        {
            if (velocity.X < PhysicsSettings.friction && velocity.X > -PhysicsSettings.friction)
            {
                return 0;
            }
            else if (velocity.X > 0)
            {
                velocity.X -= PhysicsSettings.friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += PhysicsSettings.friction;
            }
            return velocity.X;
        }

        public void StopHorizontal()
        {
            velocity.X = 0;
        }

        public void StopVertical()
        {
            velocity.Y = 0;
        }

        public void StopJump()
        {
            if (jumpCounter < PhysicsSettings.minimumJumpLimit)
            {
                isMininumJump = true;
                isDecelerating = true;
                return;
            }
            else if (!isFalling)
            {
                // Start decelerating
                isDecelerating = true;
            }
        }

    }
}
