using Mario.Entities.Abstract;
using Mario.Entities.Hero;
using Mario.Global;
using Mario.Interfaces.Base;
using Mario.Physics;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
        public HeroState currentState { get; set; }
        public bool teamMario { get; }
        public void WalkLeft();
        public void WalkRight();
        public void Jump();
        public void StopJump();
        public void SmallJump();
        public void StopHorizontal();
        public void StopVertical();
        public void Stand();
        public void Crouch();
        public void Collect(IItem item);
        public void TakeDamage();
        public void Attack();
        public void Die();
        public GlobalVariables.HeroHealth ReportHealth();
        public int GetStartingLives();
        public Vector2 GetVelocity();
        public HeroPhysics GetPhysics();
        public HeroStatTracker GetStats();
        public GlobalVariables.HorizontalDirection GetHorizontalDirection();
    }
}


