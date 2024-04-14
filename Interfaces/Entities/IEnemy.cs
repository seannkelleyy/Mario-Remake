using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase, ICollideable
    {
        public EntityPhysics physics { get; }
        public void ChangeDirection();
        public void Stomp();
        public void Flip();
        public void Collect(IItem item);
        public void Attack();
        public bool ReportIsAlive();
        public EnemyHealth ReportHealth();
        public Vector2 GetVelocity();
    }
}
