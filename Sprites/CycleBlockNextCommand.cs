using Mario.Interfaces;

namespace Mario.Sprites
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
