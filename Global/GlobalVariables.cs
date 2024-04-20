namespace Mario.Global
{
    public class GlobalVariables
    {
        // Static members are capitalized
        public static string LevelName { get; set; }
        public static int BlockHeightWidth = 16;

        public static int HalfBlockAdjustment = 8;

        public static int HorizontalBlockCollisionAdjustment = 2;

        public static int TopBlockCollisionAdjustment = 5;

        public static float SpriteUpdateInterval = 0.175f;

        public static float InputControllerUpdateInterval = 0.05f;

        public static float MaxResetTime = 4.0f;

        public static float CameraLeftEdge = 0;

        public static float CameraBottomEdge = GameSettings.ScreenSize.Y;

        public static int HUDBuffer = 50;
        public enum CollisionDirection { Top, Bottom, Left, Right, None }
        public enum HorizontalDirection { left, right };
        public enum HeroHealth { Mario, BigMario, FireMario, PistolMario, ShotgunMario, RocketLauncherMario };
        public enum EnemyHealth { Normal, Big, Fire };

        public enum BlockType
        {
            Brick,
            Floor,
            Mystery,
        }

        public enum PipeType
        {
            horizontal, vertical, tile,
        };

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
            enemyPowerup,
            vine, // Most likely will be unused.
            pipe
        }
        public enum SongThemes
        {
            ground,
            underground,
            underwater,
            castle,
            invincibility,
            levelComplete,
            castleComplete,
            lostLife,
            gameOver,
            ending,
            enemyStar
        }

        #endregion MediaManagerVariables
    }
}
