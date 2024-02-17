using Mario.Interfaces.Entities;

namespace Mario.Interfaces
{
    // This interface is just here for Sprint2, it will be deleted after
    public interface IEnemyCycle : IEntityBase
    {
        public void CycleEnemyNext();

        public void CycleEnemyPrev();

    }
}

