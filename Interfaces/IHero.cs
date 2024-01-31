using System;
using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Interfaces
{
	public interface IHero : ISprite
    {
		public void GetRectangle();

		// Movement
		public void WalkLeft();

		public void WalkRight();

		public void Jump();

		public void Crouch();

		// Actions
		// This will be a generic attack command. We could get what kind of attack
		// Based upon the state of the Hero.
		public void Attack();
	}
}

