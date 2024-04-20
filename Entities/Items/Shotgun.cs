using Mario.Entities.Items.ItemStates;
using Mario.Global;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class Shotgun : AbstractItem
    {
        public Shotgun(Vector2 position)
        {
            this.position = position;
            currentState = new ShotgunState();
        }

        public override void MakeVisible()
        {
            position.Y -= GlobalVariables.BlockHeightWidth;
            isVisible = true;
            isCollidable = true;
        }

        public override void ChangeDirection() { }

        public override Vector2 GetVelocity()
        {
            return new Vector2(0, 0);
        }
    }
}
