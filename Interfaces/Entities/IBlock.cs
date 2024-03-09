using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IBlock : IEntityBase, ICollideable
    {
        public bool isCollidable { get; set; }
        public bool isBreakable { get; set; }
        public void GetHit();
    }
}

