using Mario.Interfaces;

namespace Mario.Sprites
{
    public class DisplaySpriteCommand : ICommand
    {
        private SpriteState State;
        private MarioRemake Game;

        public DisplaySpriteCommand(SpriteState state, MarioRemake game)
        {
            State = state;
            Game = game;
        }

        public void Execute()
        {
            Game.CurrentSprite = State;
        }
    }
}
