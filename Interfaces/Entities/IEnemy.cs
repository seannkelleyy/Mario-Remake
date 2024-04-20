using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Mario.Global.GlobalVariables;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase, ICollideable
    {
#nullable enable
        public Dictionary<string, IAI>? EnemyAI { get; set; }
#nullable disable
        public EntityPhysics physics { get; }
        public bool teamMario { get; }

        public VerticalEntityPhysics verticalPhysics { get; }
        public void ChangeDirection();
        public void Stomp();
        public void Flip();
        public void Collect(IItem item);
        public void Attack();
        public bool ReportIsAlive();
        public EnemyHealth ReportHealth();
        public Vector2 GetVelocity();
        public HorizontalDirection GetCurrentDirection();
    }
}
