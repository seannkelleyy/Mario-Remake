using Mario;
using Mario.Interfaces;

namespace GreenGame.CycleCommands
{
    public class CycleBlockNextCommand : ICommand
    {
        private IBlock Block;
        private MarioRemake Game;

        public CycleBlockNextCommand(IBlock block, MarioRemake game)
        {
            Block = block;
            Game = game;
        }

        public void Execute()
        {
            Block.CycleBlockNext();
        }
    }
}
