using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Input;
using Mario.Interfaces;
using Mario.Singletons;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private GameContentManager GameContentManager;
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
            KeyboardController = new KeyboardController();
            GameContentManager = new GameContentManager();
            GameContentManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            GameContentManager.Load(Content, SpriteBatch);
            KeyboardController.LoadCommands(this, Content, SpriteBatch);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardController.Update();
            GameContentManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();
            GameContentManager.Draw(SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
