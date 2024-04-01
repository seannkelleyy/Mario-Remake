using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using static Mario.Entities.Character.Hero;

namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
        public void WalkLeft();
        public void WalkRight();
        public void Jump();
        public void SmallJump();
        public void StopHorizontal();
        public void StopVertical();
        public void Stand();
        public void Crouch();
        // Function to power up Hero. i.e.make big, firepower...
        void PowerUp(IItem item);
        void TakeDamage();
        public void Attack();
        public void Die();

        public health ReportHealth();
        public Vector2 GetVelocity();
    }
}


