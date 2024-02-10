using Mario.Interfaces;

namespace Mario.Sprites
{
    public class CycleItemPrevCommand : ICommand
    {
        private IItem Item;
        private MarioRemake Game;

        public CycleItemPrevCommand(IItem item, MarioRemake game)
        {
            Item = item;
            Game = game;
        }

        public void Execute()
        {
            Item.CycleItemPrev();
        }
    }
}
