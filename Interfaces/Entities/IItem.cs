using Mario.Interfaces;

namespace Mario.Interfaces
{
	public interface IItem : ISprite
	{
		// Cycles through to next sprite when moving
		public void CycleItemNext();

		public void CycleItemPrev();
	}
}

