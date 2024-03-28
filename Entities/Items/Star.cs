using Microsoft.Xna.Framework;
using Mario.Entities.Items.ItemStates;
using Mario.Physics;

namespace Mario.Entities.Items
{
    public class Star : AbstractItem
    {
        public Star(Vector2 position)
        {
            this.position = position;
            currentState = new StarState();
            physics = new EntityPhysics(this);
        }

        public override void MakeVisable()
        {
            IsVisable = true;
            IsCollidable = true;
        }

        // Makes the star move 
        public void Move()
        {
            physics.Update();
        }
    }
}
