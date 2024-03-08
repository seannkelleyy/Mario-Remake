﻿using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class EntityPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool verticalDirection = true; // True is down, false is up

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
                if (entity.GetCollisionState(CollisionDirection.Right) == true)
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
            }
            else if (entity.GetCollisionState(CollisionDirection.Right) == false)
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
            if (entity.GetCollisionState(CollisionDirection.Bottom) == false)
            {
                velocity.Y += ApplyGravity();
            }
            else if (entity.GetCollisionState(CollisionDirection.Bottom) == true)
            {
                velocity.Y = 0;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }

        #endregion
    }
}
