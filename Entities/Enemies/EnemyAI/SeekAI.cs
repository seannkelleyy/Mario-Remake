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
            if (Math.Abs(GameContentManager.Instance.GetHero().GetPosition().X - enemy.GetPosition().X) < (BlockHeightWidth * 12)) 
            { 
                if (GameContentManager.Instance.GetHero().GetPosition().X < enemy.GetPosition().X)
                {
                    if (enemy.physics.currentHorizontalDirection == HorizontalDirection.right)
                    {
                        if (enemy.physics.currentHorizontalDirection == HorizontalDirection.right)
                        {
                            enemy.physics.currentHorizontalDirection = HorizontalDirection.left;
                        }
                        else
                        {
                            enemy.physics.currentHorizontalDirection = HorizontalDirection.right;
                        }
                    }
                }
                else
                {
                    if (enemy.physics.currentHorizontalDirection == HorizontalDirection.left)
                    {
                        if (enemy.physics.currentHorizontalDirection == HorizontalDirection.right)
                        {
                            enemy.physics.currentHorizontalDirection = HorizontalDirection.left;
                        }
                        else
                        {
                            enemy.physics.currentHorizontalDirection = HorizontalDirection.right;
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
