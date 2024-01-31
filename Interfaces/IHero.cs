using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Interfaces
{
	public interface IHero
	{
		// Standard functions
		public void Update(GameTime gameTime);

		public void Draw(SpriteBatch spriteBatch, Vector2 position);

		public void GetRectangle();

		// Movement
		public void WalkLeft();

		public void WalkRight();

		public void Jump();

		public void Crouch();

		// Actions

		public void Attack();
	}
}

