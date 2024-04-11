using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mario.Interfaces
{
    public interface IController
    {
        void Update(GameTime gameTime);

        void UpdatePause(GameTime gameTime);

        void LoadCommands(MarioRemake game);
    }
}
