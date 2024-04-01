﻿using System.Collections.Generic;
using Mario.Entities.Abstract;
using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Mario.Global.CollisionVariables;

namespace Mario.Entities
{
	public abstract class AbstractCollideable : IEntityBase, ICollideable
    {
        internal AbstractEntityPhysics physics; // Strategy Pattern
        internal Vector2 position;
        public AbstractEntityState currentState; 
        internal Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return collisions[direction];
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            collisions[direction] = state;
        }

        public virtual Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)currentState.GetVector().X, (int)currentState.GetVector().Y);
        }

        public Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
