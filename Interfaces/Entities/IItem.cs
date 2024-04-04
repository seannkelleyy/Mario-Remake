﻿
using Mario.Interfaces.Base;

namespace Mario.Interfaces
{
    public interface IItem : IEntityBase, ICollideable
    {
        public bool isVisible { get; }
        public void MakeVisible();
        public void ChangeDirection();
    }
}

