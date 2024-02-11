using Mario;
using Mario.Interfaces;

namespace GreenGame.CycleCommands
{
    public class CycleBlockPrevCommand : ICommand
    {
        private IBlock Block;
        private MarioRemake Game;

        public CycleBlockPrevCommand(IBlock block, MarioRemake game)
        {
            Block = block;
            Game = game;
        }

        public void Execute()
        {
            Block.CycleBlockPrev();
        }
    }
}
