﻿namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase
    {
        // Movement
        public void ChangeDirection();

        // Function to handle when Enemu takes damage
        public void Stomp();
        public void Flip();
    }
}
