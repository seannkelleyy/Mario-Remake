using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Physics
{
    public abstract class AbstractEntityPhysics
    {

        public Vector2 velocity;
        public HorizontalDirection currentHorizontalDirection = HorizontalDirection.right;
        public VerticalDirection currentVerticalDirection = VerticalDirection.up;
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

        public HorizontalDirection GetHorizontalDirection()
        {
            return currentHorizontalDirection;
        }
        public VerticalDirection GetVerticalDirection()
        {
            return currentVerticalDirection;
        }

        public void SetHorizontalDirection(HorizontalDirection currentHorizontalDirection)
        {
            this.currentHorizontalDirection = currentHorizontalDirection;
        }

        public void SetVerticalDirection(VerticalDirection currentVerticalDirection)
        {
            this.currentVerticalDirection = currentVerticalDirection;
        }

        public float ApplyGravity()
        {
            if (velocity.Y < Math.Abs(PhysicsSettings.MaxVerticalSpeed))
            {
                velocity.Y += PhysicsSettings.Gravity;
            }
            else
            {
                velocity.Y = PhysicsSettings.MaxVerticalSpeed;
            }
            return velocity.Y;
        }

        public float ApplyFriction()
        {
            if (velocity.X < PhysicsSettings.Friction && velocity.X > -PhysicsSettings.Friction)
            {
                return 0;
            }
            else if (velocity.X > 0)
            {
                velocity.X -= PhysicsSettings.Friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += PhysicsSettings.Friction;
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
            if (jumpCounter < PhysicsSettings.MinimumJumpLimit)
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
