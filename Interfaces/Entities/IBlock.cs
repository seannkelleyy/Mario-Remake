using Mario.Interfaces.Entities;

namespace Mario.Interfaces
{
	public interface IBlock : IEntityBase
    {
        // Changes block sprite when it is hit etc.
        public void CycleBlockNext();

        public void CycleBlockPrev();

    }
}

