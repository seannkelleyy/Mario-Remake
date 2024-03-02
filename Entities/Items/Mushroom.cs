using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;
using System.Collections.Generic;

namespace Mario.Entities.Items
{
    public class Mushroom : AbstractItem
    {
        public bool IsCollidable { get; set; } = false;

        public Mushroom(Vector2 position, string mushroomType)
        {
            this.position = position;
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
                throw new KeyNotFoundException($"ItemBlock type {mushroomType} not recognized.");
            }
        }

        public override void MakeVisable()
        {
            IsVisable = true;
            IsCollidable = true;
        }

        // TODO: Implment more methods to handle movement
    }
}
