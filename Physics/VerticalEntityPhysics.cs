using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;

namespace Mario.Physics
{
    public class VerticalEntityPhysics : EntityPhysics
    {
        private double directionChangeTimer = 0;
        private double directionChangeInterval = 2.0; // Interval to change direction

        public VerticalEntityPhysics(ICollideable entity) : base(entity)
        {
            velocity = new Vector2(0, PhysicsSettings.InitialVerticalSpeed); // Initialize vertical speed
        }

        public void Update(GameTime gameTime)
        {
            // Call the method to handle vertical movement and pass GameTime
            HandleVerticalMovement(gameTime);
        }

        private void HandleVerticalMovement(GameTime gameTime)
        {
            directionChangeTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (directionChangeTimer >= directionChangeInterval)
            {
                directionChangeTimer = 0;
                velocity.Y = -velocity.Y; // Reverse the vertical direction
            }

            // Call the inherited UpdateVertical method
            UpdateVertical();
        }

        internal override void UpdateHorizontal()
        {
            // Disable horizontal movement by not implementing horizontal updates
        }
    }
}
