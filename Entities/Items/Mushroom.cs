using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;
using System.Collections.Generic;
using Mario.Physics;

namespace Mario.Entities.Items
{
    public class Mushroom : AbstractItem
    {
        private EntityPhysics physics;

        public Mushroom(Vector2 position, string mushroomType)
        {
            this.position = position;
            physics = new EntityPhysics(this);

            // Set the correct sprite of this item block
            if (mushroomType.CompareTo("redMushroom") == 0)
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
                Logger.Instance.LogError($"ItemBlock type {mushroomType} not recognized.");
            }
        }

        public override void MakeVisable()
        {
            IsVisable = true;
            IsCollidable = true;
        }

        public void Move()
        {
            physics.Update();
        }
    }
}
