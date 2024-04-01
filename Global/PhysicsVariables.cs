namespace Mario.Global
{
    public class PhysicsVariables
    {
        // These values are meant to be adjusted once blocks and stuff are added.
        public const float gravity = 2.3f;
        public const float friction = 0.05f;
        public const float jumpForce = 4f;
        public const float maxVerticalSpeed = 30f;
        public const float maxRunSpeed = 2f;
        public const float runAcceleration = .75f;
        public const float enemySpeed = 1f;
        public const int regularJumpLimit = 35;
        public const int smallJumpLimit = 10;

        // Fireaball physics
        public const float fireballHorizontalSpeed = 6.25f;
        public const float fireballVerticalSpeed = .9375f;
        public const float fireballBounceForce = 3.75f;
        public const float fireballDeleteInterval = .6f;
    }
}
