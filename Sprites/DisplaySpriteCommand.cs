using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    public class DisplaySpriteCommand : ICommand
    {
        private SpriteState State;
        private Game1 Game;

        public DisplaySpriteCommand(SpriteState state, Game1 game)
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
