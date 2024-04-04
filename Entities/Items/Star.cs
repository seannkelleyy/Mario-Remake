using Mario.Collisions;
using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Items
{
    public class Star : AbstractItem
    {
        public StarPhysics physics { get; set; }
        public Star(Vector2 position)
        {
            this.position = position;
            currentState = new StarState();
            physics = new StarPhysics(this);
        }

        public override void MakeVisible()
        {
            position.Y -= 16;
            isVisible = true;
            isCollidable = true;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            CollisionManager.Instance.Run(this);
            physics.Update();
            currentState.Update(gameTime);
        }

        public override void ChangeDirection()
        {
            if (physics.GetHorizontalDirection() == horizontalDirection.right)
            {
                physics.SetHorizontalDirection(horizontalDirection.left);
            }
            else
            {
                physics.SetHorizontalDirection(horizontalDirection.right);
            }
        }
        public override Vector2 GetVelocity()
        {
            return physics.GetVelocity();
        }
    }
}
