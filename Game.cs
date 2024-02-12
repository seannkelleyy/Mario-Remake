using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mario.Input;
using Mario.Interfaces;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;

        public MarioRemake()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            KeyboardController = new KeyboardController();

            KeyboardController.LoadCommands(this, Content, SpriteBatch);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            // Draws will go here

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
