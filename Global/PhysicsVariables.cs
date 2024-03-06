namespace Mario.Global
{
    public class PhysicsVariables
    {
        // These values are meant to be adjusted once blocks and stuff are added.
        public const float gravity = 2f;
        public const float jumpForce = 10f;
        public const float maxVericalSpeed = 30f;
        public const float maxRunSpeed = 3f;
        public const float runAcceleration = .75f;
        public const float friction = 0.05f;
        public const float enemyAcceleration = 0.5f;
        public const float enemyMaxSpeed = 1.5f;
        // This is the number of frames the player can jump for. Currently,
        // this does not change much except for how high the player goes.
        // Eventually we should change the keyboard controller to allow for
        // knowing when the key is released, so we can have a variable jump.
        public const int jumpLimit = 10;
    }
}
