using Mario.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;
using System;
using Mario.Interfaces.Base;
using static Mario.Global.CollisionVariables;
using System.Collections.Generic;
using Mario.Interfaces.Entities;

namespace Mario.Entities.Items
{
    public abstract class AbstractItem : IItem
    {
        public ItemState currentState;
        public Vector2 position;
        public bool IsVisable { get; set; } = false;
        public bool IsCollidable { get; set; } = false;

        // This method will only draw the item when isVisable is true. If this method is called when isVisable is false, an error will be reported
        public void Draw(SpriteBatch spriteBatch)
        {
            // If the item is still being held by a block, it should not be drawn yet
            if (IsVisable)
            {
                currentState.Draw(spriteBatch, position);
            } else
            {
                Logger.Instance.LogError("Error: Item's Draw can only be called when isVisable = true.");
            }
            
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        { 
            this.position = position;
        }

        public void HandleCollision(ICollideable entity, Dictionary<CollisionDirection, bool> collisionDirection)
        {
            if (entity is IHero)
            {
                // Makes the item disappear because it was collected
                IsVisable = false;
                IsCollidable = false;
            }
    }

        // Makes the item visable
        public abstract void MakeVisable();
    }
}
