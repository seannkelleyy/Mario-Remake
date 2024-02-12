using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mario.Interfaces
{
    public interface IController
    {
        void Update();

        void Add(Keys key, ICommand command);

        void LoadCommands(MarioRemake game, ContentManager content, SpriteBatch spriteBatch);
    }
}
