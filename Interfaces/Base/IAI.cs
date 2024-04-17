using Mario.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Interfaces.Base
{
    public interface IAI
    {
        public void Jump(IEnemy enemy);
        public void Seek(IEnemy enemy);
        public void Scare(IEnemy enemy);
    }
}
