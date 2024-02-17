using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Input;
using Mario.Interfaces;
using Mario.Singletons;
using Mario.Interfaces.Entities;
using Mario.Sprites;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager graphics;
        private GameContentManager gameContentManager;
        private SpriteBatch spriteBatch;
        private IController keyboardController;
        private IEntityBase[] entities;
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
            SpriteFactory.Instance.LoadAllTextures(Content);
            gameContentManager.Load();
            entities = gameContentManager.GetEntities();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            keyboardController.LoadCommands(this, entities);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IEntityBase entity in entities)
            {
                // This will eventually check if the entity needs to be updated
                if (entity != null)
                {
                    entity.Update(gameTime);
                }
            }   
            keyboardController.Update();
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
