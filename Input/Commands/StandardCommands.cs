using Mario.Interfaces;

namespace Mario.Input
{
    public class RestartCommand : ICommand
    {
        private MarioRemake Game;

        public RestartCommand(MarioRemake game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game = new MarioRemake();
        }
    }
}
