using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mario.Interfaces
{
    public interface IController
    {
        void Update();

        void Add(Keys key, Action action);

        void LoadCommands(MarioRemake game, IEntityBase[] entities);
    }
}
