namespace Mario.Levels.Level
{
    public class LevelPipe
    {
        public string type { get; set; }
        public int x { get; set; }
        public int startingY { get; set; }
        public int endingY { get; set; }
        public bool isTransportable { get; set; }
    }
}
