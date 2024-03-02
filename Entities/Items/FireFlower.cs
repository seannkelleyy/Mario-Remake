using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;

namespace Mario.Entities.Items
{
    public class FireFlower : AbstractItem
    {
        public bool IsCollidable { get; set; } = false;

        public FireFlower(Vector2 position)
        {
            this.position = position;
            currentState = new FireFlowerState();
        }

        public override void MakeVisable()
        {
            IsVisable = true;
            IsCollidable = true;
        }
    }
}
