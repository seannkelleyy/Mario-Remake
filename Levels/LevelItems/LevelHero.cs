namespace Mario.Levels.LevelItems
{
    public class LevelHero
    {
        public string type { get; set; }
        public int startingX { get; set; }
        public int startingY { get; set; }
        public int lives { get; set; }
        // true is right, false is left
        // small, big, fire
        public string startingPower { get; set; }
    }
}
