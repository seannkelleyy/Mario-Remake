using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase, ICollideable
    {
        public void ChangeDirection();
        public void Stomp();
        public void Flip();
        public Vector2 GetVelocity();
        public bool ReportHealth();
    }
}
