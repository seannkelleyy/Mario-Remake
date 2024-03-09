namespace Mario.Levels.Level
{
    public class LevelBlock
    {
        public string type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool collideable { get; set; }
        public bool breakable { get; set; }
        public string item { get; set; }
    }
}
