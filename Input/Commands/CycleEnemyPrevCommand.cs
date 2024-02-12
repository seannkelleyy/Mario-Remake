using Mario;
using Mario.Interfaces;

namespace GreenGame.CycleCommands
{
    public class CycleEnemyPrevCommand : ICommand
    {
        private IEnemy Enemy;
        private MarioRemake Game;

        public CycleEnemyPrevCommand(IEnemy enemy, MarioRemake game)
        {
            Enemy = enemy;
            Game = game;
        }

        public void Execute()
        {
            Enemy.CycleEnemyPrev();
        }
    }
}
