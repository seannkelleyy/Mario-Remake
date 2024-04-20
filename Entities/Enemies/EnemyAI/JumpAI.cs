using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Enemies.EnemyAI
{
    public class JumpAI : IAI 
    {

        public void Jump(IEnemy enemy)
        {
            enemy.physics.Jump();
        }

        public void Seek(IEnemy enemy)
        {
            // For JumpAI, this does nothing.
        }

        public bool Scare(IEnemy enemy, double scareCD, double scareCounter)
        {
            return false;
        }
    }
}
