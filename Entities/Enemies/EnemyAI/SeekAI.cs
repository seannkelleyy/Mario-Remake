using Mario.Entities.Abstract;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Enemies.EnemyAI
{
    public class SeekAI : IAI
    {
        public void Jump(IEnemy enemy)
        {
            // Does nothing in seek.
        }
        public void Seek(IEnemy enemy)
        {
            // Seek activation range is set by the BlockHeightWidth * 12, so 12 block activation range. 
            if (Math.Abs(GameContentManager.Instance.GetHero().GetPosition().X - enemy.GetPosition().X) < (BlockHeightWidth * 12)) 
            {
                // Checks if the enemy is to the left or to the right of the enemy.
                if (GameContentManager.Instance.GetHero().GetPosition().X < enemy.GetPosition().X)
                {
                    // Checks to see if the enemy needs to change directions, and if it does, koopa also changes state.
                    if (enemy.physics.currentHorizontalDirection == HorizontalDirection.right)
                    {
                        enemy.physics.currentHorizontalDirection = HorizontalDirection.left;
                        if (enemy is Koopa && (!((Koopa)enemy).GetIsShell()))
                        {
                            Koopa kEnemy = (Koopa)enemy;
                            kEnemy.ChangeCurrentState(new LeftMovingKoopaState());
                        }
                    }
                }
                // This is if the enemy is on the other side of the hero, and will adjust accordingly.
                else
                {
                    if (enemy.physics.currentHorizontalDirection == HorizontalDirection.left)
                    {
                        enemy.physics.currentHorizontalDirection = HorizontalDirection.right;
                        if (enemy is Koopa && (!((Koopa)enemy).GetIsShell()))
                        {
                            Koopa kEnemy = (Koopa)enemy;
                            kEnemy.ChangeCurrentState(new RightMovingKoopaState());
                        }
                    }
                }
            }
        }

        public bool Scare(IEnemy enemy, double scareCD, double scareCounter)
        {
            return false;
        }
    }
}
