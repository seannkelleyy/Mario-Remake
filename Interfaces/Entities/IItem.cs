
using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IItem : IEntityBase, ICollideable
    {
        public void MakeVisable();
    }
}

