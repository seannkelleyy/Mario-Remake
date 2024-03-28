using Mario.Entities.Items.ItemStates;
using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class Mushroom : AbstractItem
    {
        public Mushroom(Vector2 position, string mushroomType)
        {
            physics = new EntityPhysics(this);
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
                Logger.Instance.LogError($"ItemBlock type `{mushroomType}` not recognized.");
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
