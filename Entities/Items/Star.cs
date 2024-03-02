using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;

namespace Mario.Entities.Items
{
    public class Star : AbstractItem
    {
        public bool IsCollidable { get; set; } = false;

        public Star(Vector2 position)
        {
            this.position = position;
            currentState = new StarState();
        }

        public override void MakeVisable()
        {
            IsVisable = true;
            IsCollidable = true;
        }

        // TODO: Implment more methods to handle movement
    }
}
