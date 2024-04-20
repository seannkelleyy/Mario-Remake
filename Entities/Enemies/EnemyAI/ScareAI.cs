using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using System;
using static Mario.Global.GlobalVariables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Enemies.EnemyAI
{
    public class ScareAI : IAI
    {
        public void Jump(IEnemy enemy)
        {
            // Does nothing in the scare AI.
        }

        public void Seek(IEnemy enemy)
        {
            // Does nothing in the scare AI.
        }

        public bool Scare(IEnemy enemy, double scareCD, double scareCounter)
        {
            bool triggered = false;
            // No game time to increase time with. Must be done somewhere else.
            if (scareCounter > scareCD)
            {
                if (Math.Abs(GameContentManager.Instance.GetHero().GetPosition().X - enemy.GetPosition().X) < 4 * BlockHeightWidth)
                {
                    IEnemy phantom;
                    if (enemy.GetType().ToString().CompareTo("Goomba") == 0)
                    {
                        phantom = ObjectFactory.Instance.CreateEnemy("goomba", enemy.GetPosition(), new List<string>());
                    }
                    else
                    {
                        phantom = ObjectFactory.Instance.CreateEnemy("koopa", enemy.GetPosition(), new List<string>());
                    }

                    GameContentManager.Instance.AddEntity(new PhantomEnemy(phantom));

                    if (enemy.physics.currentHorizontalDirection == HorizontalDirection.right)
                    {
                        enemy.physics.currentHorizontalDirection = HorizontalDirection.left;
                        if (enemy.GetType().ToString().CompareTo("Koopa") == 0)
                        {
                            Koopa kEnemy = (Koopa)enemy;
                            kEnemy.ChangeCurrentState(new LeftMovingKoopaState());
                        }
                    }
                    else
                    {
                        enemy.physics.currentHorizontalDirection = HorizontalDirection.right;
                        if (enemy.GetType().ToString().CompareTo("Koopa") == 0)
                        {
                            Koopa kEnemy = (Koopa)enemy;
                            kEnemy.ChangeCurrentState(new RightMovingKoopaState());
                        }
                    }
                    triggered = true;
                }
            }
            return triggered;
        }
    }
}
