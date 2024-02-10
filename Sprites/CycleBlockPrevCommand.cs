using Mario.Interfaces;

namespace Mario.Sprites
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
