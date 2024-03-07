using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IBlock : IEntityBase, ICollideable
    {
        public void GetHit();
    }
}

