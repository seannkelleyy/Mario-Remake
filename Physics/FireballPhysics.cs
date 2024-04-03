using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Physics
{
    public class FireballPhysics : AbstractEntityPhysics
    {
        public FireballPhysics(ICollideable entity) : base(entity)
        {
            this.entity = entity;
            velocity = new Vector2(0, 0);
        }

        public override void Update()
        {
            if (!isFalling) UpdateHorizontal();
            else UpdateVertical();
        }

        internal override void UpdateHorizontal()
        {

        }

        internal override void UpdateVertical()
        {
        }
    }
}
