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
        public bool isRight = true; // True is right, false is left
        public bool isDown = true; // True is down, false is up
        private float jumpCounter = 0;
        private float smallJumpCounter = 0;

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
            return isRight;
        }

        public void setHorizontalDirecion(bool horizontalDirection)
        {
            this.isRight = horizontalDirection;
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
            isRight = true;
            if (!hero.GetCollisionState(CollisionDirection.Right))
            {
                if (velocity.X < PhysicsVariables.maxRunSpeed)
                {
                    velocity.X += PhysicsVariables.runAcceleration;
                }
            }
        }

        public void WalkLeft()
        {
            isRight = false;
            if (!hero.GetCollisionState(CollisionDirection.Left))
            {
                if (velocity.X > -PhysicsVariables.maxRunSpeed)
                {
                    velocity.X -= PhysicsVariables.runAcceleration;
                }
            }
        }

        // Stops Mario from moving any further when he collides with a wall
        public void StopHorizontal()
        {
            velocity.X = 0;
        }

        // Stops Mario from moving any further when he collides with a wall
        public void StopVertical()
        {
            velocity.Y = 0;
        }

        private void UpdateHorizontal()
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
            if (hero.GetCollisionState(CollisionDirection.Bottom))
            {
                isDown = false;
                velocity.Y = -PhysicsVariables.jumpForce;
                jumpCounter = 1;
            }
        }

        public void SmallJump()
        {
            if (hero.GetCollisionState(CollisionDirection.Bottom))
            {
                isDown = false;
                velocity.Y = -PhysicsVariables.jumpForce;
                smallJumpCounter = 1;
            }
        }

        private void UpdateVertical()
        {
            if (isDown)
            {
                // If Mario is not jumping, apply gravity
                if (!hero.GetCollisionState(CollisionDirection.Bottom))
                {
                    velocity.Y += ApplyGravity();
                }
                else
                { // If Mario has landed, stop moving
                    StopVertical();
                }
            }
            else
            {
                // If Mario is still within the jump limit, keep moving up
                if (smallJumpCounter > 0 && smallJumpCounter < PhysicsVariables.smallJumpLimit)
                {
                    velocity.Y = -PhysicsVariables.jumpForce * (1 - smallJumpCounter / PhysicsVariables.smallJumpLimit);
                    smallJumpCounter++;
                }
                else if (jumpCounter < PhysicsVariables.regularJumpLimit && jumpCounter > 0)
                {
                    velocity.Y = -PhysicsVariables.jumpForce * (1 - jumpCounter / PhysicsVariables.regularJumpLimit);
                    jumpCounter++;
                }
                else if (hero.GetCollisionState(CollisionDirection.Top))
                {
                    StopVertical();
                }
                else
                { // If Mario has reached the jump limit, start moving down
                    isDown = true;
                }
            }

            // If Mario has landed, reset the jump counter
            if (hero.GetCollisionState(CollisionDirection.Bottom) )
            {
                jumpCounter = 0;
            }

            hero.SetPosition(hero.GetPosition() + new Vector2(0, velocity.Y));
            StopVertical();
        }
        #endregion
    }
}
