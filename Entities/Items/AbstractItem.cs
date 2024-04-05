using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Items
{
    public abstract class AbstractItem : AbstractCollideable, IItem
    {
        public bool isVisible { get; set; } = false;
        public bool isCollidable { get; set; } = false;

        public new virtual void Draw(SpriteBatch spriteBatch)
        {
            // If the item is still being held by a block, it should not be drawn yet
            if (isVisible)
            {
                currentState.Draw(spriteBatch, position);
            }
            else
            {
                Logger.Instance.LogError("Error: Item's Draw can only be called when isVisable = true.");
            }
        }

        public override void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
        }

        public abstract void ChangeDirection();

        public abstract void MakeVisible();
        public abstract Vector2 GetVelocity();
    }
}
