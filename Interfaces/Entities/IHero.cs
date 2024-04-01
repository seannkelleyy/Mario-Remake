using Mario.Interfaces.Base;

namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
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
    }
}

