
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces
{
    public interface IItem : IEntityBase, ICollideable
    {
        public bool isVisible { get; }
        public void MakeVisible();
        public void ChangeDirection();
        public Vector2 GetVelocity();
    }
}

