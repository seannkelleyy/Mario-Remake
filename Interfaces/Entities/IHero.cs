﻿using Mario.Entities.Character.HeroStates;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Interfaces.Entities
{
    public interface IHero : IEntityBase, ICollideable
    {
        public HeroState currentState { get; set; }
        public void WalkLeft();
        public void WalkRight();
        public void Jump();
        public void SmallJump();
        public void StopHorizontal();
        public void StopVertical();
        public void Crouch();
        void Collect(IItem item);
        void TakeDamage();
        public void Attack();
        public void Die();
        public int ReportHealth();
        public Vector2 GetVelocity();
    }
}

