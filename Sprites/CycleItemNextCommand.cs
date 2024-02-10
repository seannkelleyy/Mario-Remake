using Mario.Interfaces;

namespace Mario.Sprites
{
    public class CycleItemNextCommand : ICommand
    {
        private IItem Item;
        private MarioRemake Game;

        public CycleItemNextCommand(IItem item, MarioRemake game)
        {
            Item = item;
            Game = game;
        }

        public void Execute()
        {
            Item.CycleItemNext();
        }
    }
}
