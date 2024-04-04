using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Mario.Collisions;
using static Mario.Global.CollisionVariables;
using System;

namespace Mario.Entities.Items
{
    public class Star : AbstractItem
    {
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
            if (physics.isRight)
            {
                physics.isRight = false;
            }
            else
            {
                physics.isRight = true;
            }
        }
    }
}
