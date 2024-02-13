using Mario.Interfaces;

namespace Mario.Input
{
    public class QuitCommand : ICommand
    {
        private MarioRemake Game;

        public QuitCommand(MarioRemake game)
        {
            Game = game;
        }

        public void Execute()
        {
            Game.Exit();
        }
    }

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
