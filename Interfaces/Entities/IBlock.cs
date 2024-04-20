using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IBlock : IEntityBase, ICollideable
    {
        public bool isCollideable { get; set; }
        public bool isBreakable { get; set; }
        public bool canBeCombined { get; set; }
        public void GetHit();
    }
}

