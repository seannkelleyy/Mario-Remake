using Mario.Collisions;
using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Items
{
    public class Mushroom : AbstractItem
    {
        public EntityPhysics physics { get; set; }
        private bool isOneUp = false;
        public Mushroom(Vector2 position, string mushroomType)
        {
            physics = new EntityPhysics(this);
            this.position = position;
            // Set the correct sprite of this item block
            if (mushroomType.CompareTo("red") == 0)
            {
                currentState = new MushroomState();
            }
            else if (mushroomType.CompareTo("oneUp") == 0)
            {
                currentState = new OneUpState();
                isOneUp = true;
            }
            else
            {
                // Error passing in mushroom type, do something
                Logger.Instance.LogError($"ItemBlock type `{mushroomType}` not recognized.");
            }
        }

        public override void MakeVisible()
        {
            position.Y -= BlockHeightWidth;
            isVisible = true;
            isCollidable = true;
        }
        public bool IsOneUp()
        {
            return isOneUp;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            CollisionManager.Instance.Run(this);
            currentState.Update(gameTime);
            physics.Update();
        }

        public override void ChangeDirection()
        {
            if (physics.GetHorizontalDirection() == HorizontalDirection.right)
            {
                physics.SetHorizontalDirection(HorizontalDirection.left);
            }
            else
            {
                physics.SetHorizontalDirection(HorizontalDirection.right);
            }
        }
        public override Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
