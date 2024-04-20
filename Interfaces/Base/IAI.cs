using Mario.Interfaces.Entities;

namespace Mario.Interfaces.Base
{
    public interface IAI
    {
        public void Jump(IEnemy enemy);
        public void Seek(IEnemy enemy);
        public bool Scare(IEnemy enemy, double scareCD, double scareCounter);
    }
}
