using Microsoft.Xna.Framework;
using Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGame.Interfaces.Entities
{
    public interface IHeroState
    {
        // Movement
        public void ChangeDirection();

        void Update(GameTime gameTime);
    }
}

