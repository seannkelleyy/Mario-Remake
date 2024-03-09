namespace Mario.Levels.Level
{
    public class LevelBlockSection
    {
        public string type { get; set; }
        public int startingX { get; set; }
        public int startingY { get; set; }
        public int endingX { get; set; }
        public int endingY { get; set; }
        public bool collideable { get; set; }
        public bool breakable { get; set; }
        public string item { get; set; }
    }
}
