using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class EntityPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool verticalDirection = true; // True is down, false is up

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


        public ICollideable entity;

        public EntityPhysics(ICollideable entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public void Update()
        {
            UpdateHorizontal();
            UpdateVertical(); //This works, but since we hav eno collision they just fly off the screen
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

        // Keep enttity moving until they collide with something, then flip direction
        private void UpdateHorizontal()
        {
            // If the player is not pressing any keys, apply friction
            if (horizontalDirection)
            {
                if (velocity.X < PhysicsVariables.enemyMaxSpeed)
                {
                    velocity.X += PhysicsVariables.enemyAcceleration;
                }
                else
                {
                    velocity.X = PhysicsVariables.enemyMaxSpeed;
                }
            }
            else if (!horizontalDirection)
            {
                if (velocity.X > -PhysicsVariables.enemyMaxSpeed)
                {
                    velocity.X -= PhysicsVariables.enemyAcceleration;
                }
                else
                {
                    velocity.X = -PhysicsVariables.enemyMaxSpeed;
                }
            }

            entity.SetPosition(entity.GetPosition() + new Vector2(velocity.X, 0));
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

        // Much simpler than Hero's movement because they can jump, they just fall if they
        // walk off a ledge
        private void UpdateVertical()
        {
            if (collisionStates[CollisionDirection.None] == true)
            {
                velocity.Y += ApplyGravity();
            }
            else if (collisionStates[CollisionDirection.Bottom] == true)
            {
                velocity.Y = 0;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }

        #endregion
    }
}
