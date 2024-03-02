using Mario.Global;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Mario.Entities.Hero
{
    public class HeroPhysics
    {
        public Vector2 velocity;
        public bool direction = true;

        public HeroPhysics()
        {
            velocity = new Vector2(0, 0);
        }

        public float ApplyGravity()
        {
            if (velocity.Y < PhysicsVariables.maxFallSpeed)
            {
                velocity.Y += PhysicsVariables.gravity;
                Debug.WriteLine(velocity.Y);
            }
            else
            {
                velocity.Y = PhysicsVariables.maxFallSpeed;
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
        public float WalkRight()
        {
            Debug.WriteLine(velocity.X);
            direction = true;
            if (velocity.X < PhysicsVariables.maxRunSpeed)
            {
                velocity.X += PhysicsVariables.runAcceleration;
            }
            return velocity.X;
        }
        public float WalkLeft()
        {
            Debug.WriteLine(velocity.X);
            direction = false;
            if (velocity.X > -PhysicsVariables.maxRunSpeed)
            {
                velocity.X -= PhysicsVariables.runAcceleration;
            }
            return velocity.X;
        }

        public float Jump()
        {
            velocity.Y = PhysicsVariables.jumpForce;
            return velocity.Y;
        }
    }
}
