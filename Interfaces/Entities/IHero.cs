using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
        public HeroPhysics physics { get; }
        public void WalkLeft();
        public void WalkRight();
        public void Jump();
        public void StopJump();
        public void SmallJump();
        public void StopHorizontal();
        public void StopVertical();
        public void Crouch();
        public void Collect(IItem item);
        public void TakeDamage();
        public void Attack();
        public void Die();
        public int ReportHealth();
        public Vector2 GetVelocity();
    }
}

