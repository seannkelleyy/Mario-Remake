using Mario.Entities.Items;
using Mario.Interfaces.Base;

namespace Mario.Global.Settings
{
    public class ScoreSettings
    {
        public static int KoopaScore { get; set; }
        public static int GoombaScore { get; set; }
        public static int PiranhaScore { get; set; }
        public static int BulletScore { get; set; }
        public static int CoinScore { get; set; }
        public static int FireFlowerScore { get; set; }
        public static int StarScore { get; set; }
        public static int MushroomScore { get; set; }
        public static int TimeScore { get; set; }
        public static int FlagScore { get; set; }
        public static int BreakBlockScore { get; set; }

        public static int GetScore(ICollideable entity)
        {
            switch (entity)
            {
                case Koopa _:
                    return KoopaScore;
                case Goomba _:
                    return GoombaScore;
                //case "piranha":
                //    return PiranhaScore;
                //case "bullet":
                //    return BulletScore;
                case Coin:
                    return CoinScore;
                case Mushroom:
                    return MushroomScore;
                case FireFlower:
                    return FireFlowerScore;
                case Star:
                    return StarScore;
                default:
                    return 0;
            }
        }
    }
}
