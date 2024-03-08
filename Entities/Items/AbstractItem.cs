using Mario.Entities.Items.ItemStates;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

namespace Mario.Entities.Items
{
    public abstract class AbstractItem : IItem
    {
        public ItemState currentState;
        public Vector2 position;
        public bool IsVisable { get; set; } = false;
        public bool IsCollidable { get; set; } = false;
        private Dictionary<CollisionDirection, bool> collisions = new Dictionary<CollisionDirection, bool>()
        {
            { CollisionDirection.Top, false },
            { CollisionDirection.Bottom, false },
            { CollisionDirection.Left, false },
            { CollisionDirection.Right, false },
            { CollisionDirection.None, true }
        };

        // This method will only draw the item when isVisable is true. If this method is called when isVisable is false, an error will be reported
        public void Draw(SpriteBatch spriteBatch)
        {
            // If the item is still being held by a block, it should not be drawn yet
            if (IsVisable)
            {
                currentState.Draw(spriteBatch, position);
            }
            else
            {
                Logger.Instance.LogError("Error: Item's Draw can only be called when isVisable = true.");
            }

        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            // Reset all collision states to false at the start of each update
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public Rectangle GetRectangle()
        {
            return currentState.GetRectangle();
        }

        public void SetCollisionState(CollisionDirection direction, bool state)
        {
            collisions[direction] = state;
        }

        public bool GetCollisionState(CollisionDirection direction)
        {
            return collisions[direction];
        }

        // Makes the item visable
        public abstract void MakeVisable();
    }
}
