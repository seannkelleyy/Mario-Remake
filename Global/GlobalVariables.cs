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

        #region MediaManagerVariables

        public enum Levels
        {
            level1 = 1,
            level2 = 2,
            level3 = 3,
            level4 = 4,
            level5 = 5,
            level6 = 6,
            level7 = 7,
            level8 = 8
        }
        public enum EffectNames
        {
            oneUp,
            bigJump,
            breakBlock,
            bumpBlock,
            coin,
            enemyFire,
            fireball,
            flag,
            itemFromBlock,
            kick,
            smallJump,
            stomp,
            pause,
            powerup,
            vine, // Most likely will be unused.
            pipe
        }
        public enum SongThemes
        {
            ground,
            underground,
            invincibility,
            levelComplete,
            lostLife,
            gameOver
        }

        #endregion MediaManagerVariables
    }
}
