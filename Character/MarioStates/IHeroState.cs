using Microsoft.Xna.Framework;
using Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GreenGame.Character.MarioStates
{
    public interface IHeroState
    {
        // Movement
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position);
    }
}

