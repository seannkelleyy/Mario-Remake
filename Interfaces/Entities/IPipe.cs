using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;

namespace Mario.Interfaces
{
    public interface IPipe : IEntityBase, ICollideable
    {
        public bool isCollidable { get; set; }
        public void Transport(IHero mario);
        public GlobalVariables.PipeType GetPipeType();
    }
}

