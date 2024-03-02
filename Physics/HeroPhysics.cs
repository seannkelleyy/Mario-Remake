using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class HeroPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool verticalDirection = true; // True is down, false is up
        private bool isJumping = false;
        private float jumpCounter = 0;
        public Dictionary<CollisionDirection, bool> collisionStates = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };


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
            if (hero.GetPosition().Y >= 400)
            {
                Debug.WriteLineIf(collisionStates[CollisionDirection.Bottom], "Bottom collision");
                collisionStates[CollisionDirection.Bottom] = true;
                collisionStates[CollisionDirection.None] = false;
            }
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
            if (velocity.X < PhysicsVariables.maxRunSpeed)
            {
                velocity.X += PhysicsVariables.runAcceleration;
            }
        }

        public void WalkLeft()
        {
            horizontalDirection = false;
            if (velocity.X > -PhysicsVariables.maxRunSpeed)
            {
                velocity.X -= PhysicsVariables.runAcceleration;
            }
        }

        private void UpdateHorizontal()
        {
            // If the player is not pressing any keys, apply friction
            if (horizontalDirection && velocity.X > 0)
            {
                velocity.X -= PhysicsVariables.friction;
            }
            else if (!horizontalDirection && velocity.X < 0)
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
            if (!isJumping)
            {
                isJumping = true;
                velocity.Y = -PhysicsVariables.jumpForce;
                jumpCounter = 0;
            }
        }

        private void UpdateVertical()
        {
            if (isJumping)
            {
                // If Mario is still within the jump limit, keep moving up
                if (jumpCounter < PhysicsVariables.jumpLimit && jumpCounter >= 0)
                {
                    collisionStates[CollisionDirection.Bottom] = false;
                    jumpCounter++;
                    Debug.WriteLine(jumpCounter);
                }
                else if (collisionStates[CollisionDirection.Bottom] == true)
                {
                    jumpCounter = 0;
                    isJumping = false;
                }
            }

            // If Mario is not jumping, apply gravity
            if (!isJumping)
            {
                if (collisionStates[CollisionDirection.Bottom] != true)
                {
                    velocity.Y += ApplyGravity();
                }
                else
                {
                    velocity.Y = 0;
                    isJumping = false;
                }
            }
            hero.SetPosition(hero.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }

        #endregion
    }
}
