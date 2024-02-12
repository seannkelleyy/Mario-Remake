using Mario.Interfaces;

namespace GreenGame.Interfaces
{
	public interface IBlock : ISprite
    {
        // Changes block sprite when it is hit etc.
        public void CycleBlockNext();

        public void CycleBlockPrev();

    }
}

