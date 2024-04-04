using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;

namespace Mario.Entities.Items
{
    public class FireFlower : AbstractItem
    {
        public FireFlower(Vector2 position)
        {
            this.position = position;
            currentState = new FireFlowerState();
        }

        public override void MakeVisible()
        {
            position.Y -= 16;
            isVisible = true;
            isCollidable = true;
        }

        public override void ChangeDirection()
        {
            Logger.Instance.LogInformation("ChangeDirection not implemented in FireFlower");
        }
    }
}
