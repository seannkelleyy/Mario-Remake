﻿using Mario.Interfaces.Base;
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
        private int scareCD = 0;
        private int scareCounter = 0;
        public void Jump(IEnemy enemy)
        {
            // Does nothing in the scare AI.
        }

        public void Seek(IEnemy enemy)
        {
            // Does nothing in the scare AI.
        }

        public void Scare(IEnemy enemy)
        {
            // No game time to increase time with. Must be done somewhere else.
            if (scareCounter > scareCD)
            {
                if (Math.Abs(GameContentManager.Instance.GetHero().GetPosition().X - enemy.GetPosition().X) < 4 * BlockHeightWidth)
                {
                    GameContentManager.Instance.AddEntity(new PhantomEnemy(enemy));
                    scareCD = 30;
                    scareCounter = 0;
                }
            }
        }
    }
}
