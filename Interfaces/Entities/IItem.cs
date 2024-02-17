
using Mario.Interfaces.Entities;

namespace Mario.Interfaces
{
	public interface IItem : IEntityBase
	{
        public void CycleItemNext();
		public void CycleItemPrev();
	}
}

