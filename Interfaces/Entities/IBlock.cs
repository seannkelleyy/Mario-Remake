using Mario.Interfaces;

namespace Mario.Interfaces
{
	public interface IBlock
    {
        // Changes block sprite when it is hit etc.
        public void CycleBlockNext();

        public void CycleBlockPrev();

    }
}

