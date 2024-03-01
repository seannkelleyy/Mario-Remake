using Microsoft.Xna.Framework;

namespace Mario.Entities.Hero
{
    public class HeroPhysics
    {
        public Vector2 velocity;
        private const float gravity = 9.8f;
        private const float jumpForce = 15f;
        private const float maxFallSpeed = 20f;
        private const float maxRunSpeed = 5f;
        private const float runAcceleration = 0.5f;
        private const float friction = 0.5f;
        private bool direction;

        public HeroPhysics(bool direction)
        {
            this.direction = direction;
            velocity = new Vector2(0, 0);
        }
        public void Update(GameTime gameTime)
        {
            ApplyGravity();
            ApplyFriction();
            ApplySpeed();
        }

        private void ApplyGravity()
        {
            if (velocity.Y < maxFallSpeed)
            {
                velocity.Y += gravity;
            }
        }

        private void ApplyFriction()
        {
            if (velocity.X > 0)
            {
                velocity.X -= friction;
            }
            else if (velocity.X < 0)
            {
                velocity.X += friction;
            }
        }
        private void ApplySpeed()
        {
            if (direction)
            {
                if (velocity.X < maxRunSpeed)
                {
                    velocity.X += runAcceleration;
                }
            }
            else
            {
                if (velocity.X > -maxRunSpeed)
                {
                    velocity.X -= runAcceleration;
                }
            }
        }

        public float Jump()
        {
            velocity.Y = -jumpForce;
            return velocity.Y;
        }
    }
}
