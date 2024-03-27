using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

namespace Mario.Physics
{
    public class EntityPhysics
    {
        public Vector2 velocity;
        public bool horizontalDirection = true; // True is right, false is left
        public bool isFalling = true; // True is down, false is up

        public ICollideable entity;

        public EntityPhysics(ICollideable entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public void Update()
        {
            if (!isFalling) UpdateHorizontal();
            else UpdateVertical();
        }
        public Vector2 GetVelocity()
        {
            return velocity;
        }

        #region Horizontal Movementss

        private void UpdateHorizontal()
        {
            if (horizontalDirection && !entity.GetCollisionState(CollisionDirection.Right))
            {
                // if (entity is IEnemy)
                    velocity.X = PhysicsVariables.enemySpeed;
            }
            else if (!horizontalDirection && !entity.GetCollisionState(CollisionDirection.Left))
            {
                    velocity.X = -PhysicsVariables.enemySpeed;
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

            if (!entity.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = true;
                velocity.Y += ApplyGravity();
            }
            else if (entity.GetCollisionState(CollisionDirection.Bottom))
            {
                velocity.Y = 0;
                isFalling = false;
            }
            entity.SetPosition(entity.GetPosition() + new Vector2(0, velocity.Y));
            velocity.Y = 0;
        }

        #endregion
    }
}
