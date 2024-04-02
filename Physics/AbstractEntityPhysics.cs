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
    }
}
