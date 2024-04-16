using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase, ICollideable
    {
        
        public void ChangeDirection();
        public void Stomp();
        public void Flip();
        public bool ReportIsAlive();
        public Vector2 GetVelocity();
    }
}
