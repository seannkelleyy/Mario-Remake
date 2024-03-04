using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class HeroPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool verticalDirection = true; // True is down, false is up
        private float jumpCounter = 0;

        // This is a dictionary that keeps track of the collision states of the entity, This could 
        // based upon exactly how we want to handle collisions, but for now, we are just going to
        // keep track of the collision states of the entity
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
            if (hero.GetPosition().Y >= 174) // Would change to collision on bottom
            {
                // This will change after full collision handling is implemented. 
                // This is mainly here so we can test the jump mechanic
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
            if (verticalDirection && collisionStates[CollisionDirection.Bottom])
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
                    collisionStates[CollisionDirection.Bottom] = false;
                    velocity.Y = -PhysicsVariables.jumpForce * (1 - (float)jumpCounter / PhysicsVariables.jumpLimit);
                    jumpCounter++;
                }
                else
                { // If Mario has reached the jump limit, start moving down
                    verticalDirection = true;
                }
            }
            else
            {
                // If Mario is not jumping, apply gravity
                if (collisionStates[CollisionDirection.Bottom] == false)
                {
                    velocity.Y += ApplyGravity();
                }
                else
                { // If Mario has landed, stop moving
                    velocity.Y = 0;
                }
            }

            // If Mario has landed, reset the jump counter
            if (collisionStates[CollisionDirection.Bottom] == true)
            {
                jumpCounter = 0;
            }

            hero.SetPosition(hero.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }


        #endregion
    }
}
