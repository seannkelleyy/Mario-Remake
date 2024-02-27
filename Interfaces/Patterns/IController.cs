using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mario.Interfaces
{
    public interface IController
    {
        void Update(GameTime gameTime);

        void Add(Keys key, Action action);

        void LoadCommands(MarioRemake game, IEntityBase[] entities);
    }
}
