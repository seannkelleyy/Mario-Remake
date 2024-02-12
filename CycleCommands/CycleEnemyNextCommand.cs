using Mario;
using Mario.Interfaces;

namespace GreenGame.CycleCommands
{
    public class CycleEnemyNextCommand : ICommand
    {
        private IEnemy Enemy;
        private MarioRemake Game;

        public CycleEnemyNextCommand(IEnemy enemy, MarioRemake game)
        {
            Enemy = enemy;
            Game = game;
        }

        public void Execute()
        {
            Enemy.CycleEnemyNext();
        }
    }
}
