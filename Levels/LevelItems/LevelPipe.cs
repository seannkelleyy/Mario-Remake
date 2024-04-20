namespace Mario.Levels.Level
{
    public class LevelPipe
    {
        public string type { get; set; }
        public int x { get; set; }
        public int startingY { get; set; }
        public int endingY { get; set; }
        public bool transportable { get; set; }
        public int transportDestinationX { get; set; }
        public int transportDestinationY { get; set; }
        public bool collidable { get; set; }
        public bool breakable { get; set; }
    }
}
