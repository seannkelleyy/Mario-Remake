
using Mario.Interfaces.Base;
using Mario.Physics;

namespace Mario.Interfaces
{
    public interface IItem : IEntityBase, ICollideable
    {
        public EntityPhysics physics { get; set; }
        public bool isVisible { get; }
        public void MakeVisible();
        public void ChangeDirection();
    }
}

