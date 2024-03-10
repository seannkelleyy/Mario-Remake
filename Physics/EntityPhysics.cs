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
            UpdateVertical();
        }
        public Vector2 GetVelocity()
        {
            return velocity;
        }

        #region Horizontal Movementss

        // Keep enttity moving until they collide with something, then flip direction
        private void UpdateHorizontal()
        {
            if (horizontalDirection && !entity.GetCollisionState(CollisionDirection.Right))
            {
                    velocity.X = PhysicsVariables.enemySpeed;
            }
            else if (!horizontalDirection && !entity.GetCollisionState(CollisionDirection.Left))
            {
                    velocity.X = -PhysicsVariables.enemySpeed;
            }
            if (entity.GetCollisionState(CollisionDirection.Left))
            {
                Logger.Instance.LogInformation($"{entity} direction flipped to right");
                horizontalDirection = true;
            }
            else if (entity.GetCollisionState(CollisionDirection.Right))
            {
                Logger.Instance.LogInformation($"{entity} direction flipped to left");

                horizontalDirection = false;
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

        private void UpdateVertical()
        {

            //Logger.Instance.LogInformation($"Updating vertical: {entity.GetCollisionState(CollisionDirection.Bottom)}");
            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y += ApplyGravity();
            }
            else if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y = 0;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }

        #endregion
    }
}
