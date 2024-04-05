namespace Mario.Global
{
    public class GlobalVariables
    {
        public static int blockHeightWidth = 16;

        public static int halfBlockAdjustment = 8;

        public static int horizontalBlockCollisionAdjustment = 2;

        public static int topBlockCollisionAdjustment = 5;

        public static float spriteUpdateInterval = 0.175f;


        public static float keyboardUpdateInterval = 0.05f;

        public enum CollisionDirection { Top, Bottom, Left, Right, None }
        public enum horizontalDirection { left, right };

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
