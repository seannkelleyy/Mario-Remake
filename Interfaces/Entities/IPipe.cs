using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IPipe : IEntityBase, ICollideable
    {
        public bool isCollidable { get; set; }
        public bool isTransport { get; set; }
    }
}
