﻿using Mario.Interfaces.Base;

namespace Mario.Interfaces.Entities
{
    public interface IEnemy : IEntityBase, ICollideable
    {
        public void ChangeDirection();
        public void Stomp();
        public void Flip();
        public bool ReportIsAlive();
    }
}
