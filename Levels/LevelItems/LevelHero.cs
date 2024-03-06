namespace Mario.Levels.LevelItems
{
    public class LevelHero
    {
        public string type { get; set; }
        public int startingX { get; set; }
        public int startingY { get; set; }
        // true is right, false is left
        public bool startingDirection { get; set; }
        // small, big, fire
        public string startingPower { get; set; }
    }
}
