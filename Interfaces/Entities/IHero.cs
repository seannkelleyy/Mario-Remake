namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
        public void WalkLeft();
        public void WalkRight();
        public void Jump();
        // Only for 'big' hereos. Implementation could change with state.
        public void Crouch();
        // Function to power up Hero. i.e.make big, firepower...
        void Collect(IItem item);
        void TakeDamage();
        public void Attack();
        public void Die();
    }
}

