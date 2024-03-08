using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

namespace Mario.Entities.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        internal BlockState currentState;
        internal Vector2 position;
        public bool isCollidable { get; set; }
        public bool isBreakable { get; set; }

        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public virtual void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
        }

        public abstract void GetHit();

        public Vector2 GetPosition()
        {
            return position;
        }
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return collisions[direction];
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            collisions[direction] = state;
        }

        public Rectangle GetRectangle()
        {
            return currentState.GetRectangle();
        }
    }
}
