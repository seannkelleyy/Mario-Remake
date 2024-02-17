using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Input;
using Mario.Interfaces;
using Mario.Singletons;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager graphics;
        private GameContentManager gameContentManager;
        private SpriteBatch spriteBatch;
        private IController keyboardController;
        public MarioRemake()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gameContentManager = new GameContentManager();
            gameContentManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            keyboardController.LoadCommands(this, Content, spriteBatch);
            gameContentManager.Load(Content, spriteBatch);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            gameContentManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            gameContentManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
