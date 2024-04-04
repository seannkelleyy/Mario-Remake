using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;
using System;
using Mario.Collisions;

namespace Mario.Entities.Items
{
    public class Mushroom : AbstractItem
    {
        public Mushroom(Vector2 position, string mushroomType)
        {
            physics = new EntityPhysics(this);
            this.position = position;
            // Set the correct sprite of this item block
            if (mushroomType.CompareTo("red") == 0)
            {
                currentState = new MushroomState();
            }
            else if (mushroomType.CompareTo("1up") == 0)
            {
                currentState = new OneUpState();
            }
            else
            {
                // Error passing in mushroom type, do something
                Logger.Instance.LogError($"ItemBlock type `{mushroomType}` not recognized.");
            }
        }

        public override void MakeVisible()
        {
            position.Y -= 16;
            isVisible = true;
            isCollidable = true;
        }
        public bool is1up()
        {
            return is1up();
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
