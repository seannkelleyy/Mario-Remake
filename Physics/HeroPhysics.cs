using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class HeroPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool verticalDirection = true; // True is down, false is up
        private float jumpCounter = 0;

        public IHero hero;

        public HeroPhysics(IHero hero)
        {
            this.hero = hero;
            velocity = new Vector2(0, 0);
        }

        public void Update()
        {
            UpdateHorizontal();
            UpdateVertical();
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }
        public bool getHorizontalDirecion()
        {
            return horizontalDirection;
        }

        public void setHorizontalDirecion(bool horizontalDirection)
        {
            this.horizontalDirection = horizontalDirection;
        }

        #region Horizontal Movement
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

        public void WalkRight()
        {
            horizontalDirection = true;
            if (hero.GetCollisionState(CollisionDirection.Right) == false)
            {
                if (velocity.X < PhysicsVariables.maxRunSpeed)
                {
                    velocity.X += PhysicsVariables.runAcceleration;
                }
            }
        }

        public void WalkLeft()
        {
            horizontalDirection = false;
            if (hero.GetCollisionState(CollisionDirection.Left) == false)
            {
                if (velocity.X > -PhysicsVariables.maxRunSpeed)
                {
                    velocity.X -= PhysicsVariables.runAcceleration;
                }
            }
        }

        private void UpdateHorizontal()
        {
            if (Math.Abs(velocity.X) < PhysicsVariables.friction)
            {
                velocity.X = 0;
            }

            hero.SetPosition(hero.GetPosition() + new Vector2(velocity.X, 0));
        }
        #endregion

        #region Vertical Movement
        public float ApplyGravity()
        {
            if (velocity.Y < Math.Abs(PhysicsVariables.maxVericalSpeed))
            {
                velocity.Y += PhysicsVariables.gravity;
            }
            else
            {
                velocity.Y = PhysicsVariables.maxVericalSpeed;
            }
            return velocity.Y;
        }
        public void Jump()
        {
            Logger.Instance.LogInformation("Jumping");
            Logger.Instance.LogInformation("Bottom: " + hero.GetCollisionState(CollisionDirection.Bottom));
            // Cant figure out why this is false when you are colliding with the ground. Cntrl + F "Jump" to see the log
            if (verticalDirection && hero.GetCollisionState(CollisionDirection.Bottom))
            {
                verticalDirection = false;
                velocity.Y = -PhysicsVariables.jumpForce;
                jumpCounter = 0;
            }
        }

        private void UpdateVertical()
        {
            if (!verticalDirection)
            {
                // If Mario is still within the jump limit, keep moving up
                if (jumpCounter < PhysicsVariables.jumpLimit)
                {
                    // maybe set bottom collision to false here
                    velocity.Y = -PhysicsVariables.jumpForce * (1 - jumpCounter / PhysicsVariables.jumpLimit);
                    jumpCounter++;
                }
                else if (hero.GetCollisionState(CollisionDirection.Top))
                {
                    velocity.Y = 0;
                }
                else
                { // If Mario has reached the jump limit, start moving down
                    verticalDirection = true;
                }
            }
            else
            {
                // If Mario is not jumping, apply gravity
                if (hero.GetCollisionState(CollisionDirection.Bottom) == false)
                {
                    velocity.Y += ApplyGravity();
                }
                else
                { // If Mario has landed, stop moving
                    velocity.Y = 0;
                }
            }

            // If Mario has landed, reset the jump counter
            if (hero.GetCollisionState(CollisionDirection.Bottom) == true)
            {
                jumpCounter = 0;
            }

            hero.SetPosition(hero.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }


        #endregion
    }
}
