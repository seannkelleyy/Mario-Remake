using Mario.Global;
using System;
using Microsoft.Xna.Framework;
using Mario.Interfaces.Base;

namespace Mario.Physics
{
	public abstract class AbstractEntityPhysics
	{

        public Vector2 velocity;
        public bool isRight = true;
        public bool isFalling = true;
        public bool isMininumJump = false;
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

        public abstract void WalkLeft();

        public abstract void WalkRight();

        public abstract void Jump();

        public abstract void SmallJump();

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public bool getHorizontalDirection()
        {
            return isRight;
        }

        public void setHorizontalDirection(bool horizontalDirection)
        {
            isRight = horizontalDirection;
        }

        public float ApplyGravity()
        {
            if (velocity.Y < Math.Abs(PhysicsVariables.maxVerticalSpeed))
            {
                velocity.Y += PhysicsVariables.gravity;
            }
            else
            {
                velocity.Y = PhysicsVariables.maxVerticalSpeed;
            }
            return velocity.Y;
        }

        public float ApplyFriction()
        {
            if (velocity.X < PhysicsVariables.friction && velocity.X > -PhysicsVariables.friction)
            {
                return 0;
            }
            else if (velocity.X > 0)
            {
                velocity.X -= PhysicsVariables.friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += PhysicsVariables.friction;
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
            if (jumpCounter < PhysicsVariables.minimumJump)
            {
                isMininumJump = true;
                return;
            }
            else if (!isFalling)
            {
                velocity.Y = 0;
                isFalling = true;
            }
        }
    }
}
