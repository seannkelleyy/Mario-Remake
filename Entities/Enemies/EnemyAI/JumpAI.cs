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
            if (enemy.GetCollisionState(CollisionDirection.Bottom))
            {
                isFalling = false;
                velocity.Y = -PhysicsSettings.JumpForce;
                jumpCounter = 1;
            }
        }

        public void Seek()
        {
            // For JumpAI, this does nothing.
        }

        public void Scare()
        {
            // For JumpAI, this does nothing.
        }
    }
}
