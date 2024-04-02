namespace Mario.Global
{
    public class GlobalVariables
    {
        public static int blockHeightWidth = 16;

        public static int halfBlockAdjustment = 8;

        public static int horizontalBlockCollisionAdjustment = 2;

        public static int topBlockCollisionAdjustment = 5;

        public static int heroMaxHealth = 3;

        public static float spriteUpdateInterval = .2f;

        public static float keyboardUpdateInterval = .1f;

        public enum CollisionDirection { Top, Bottom, Left, Right, None}

        public enum HeroStateType
        {
            StandingRight,
            StandingLeft,
            MovingRight,
            MovingLeft,
            JumpingRight,
            JumpingLeft,
            AttackingRight,
            AttackingLeft,
            Crouching,
            Dead
        }

        public enum BlockType
        {
            Brick,
            Floor,
            Mystery,
        }

        public enum ItemTypes
        {
            Coin,
            FireFlower,
            Star,
            Mushroom,
            OneUp
        }
    }
}
