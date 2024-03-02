using Mario.Global;
using Mario.Input;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager graphics;
        private GameContentManager gameContentManager;
        private SpriteBatch spriteBatch;
        private IController keyboardController;
        private IEntityBase[] entities;

        int totalFrames = 0;
        float elapsedTime = 0.0f;
        int fps = 0;

        public MarioRemake()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController();
            gameContentManager = GameContentManager.Instance;
            gameContentManager.Initialize();

            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / GameSettings.frameRate);

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
            foreach (IEntityBase entity in gameContentManager.GetEntities())
            {
                // This will eventually check if the entity needs to be updated
                if (entity != null)
                {
                    entity.Update(gameTime);
                }
            }
            keyboardController.Update(gameTime);

            totalFrames++;

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // 1000 ms = 1 second
            if (elapsedTime >= 1000.0f)
            {
                fps = totalFrames;
                totalFrames = 0;
                elapsedTime = 0;
            }
            Debug.WriteLine(fps);
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

        // Restarts the game
        public void Restart()
        {
            String currentApplication = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentApplication);
            Environment.Exit(0);
        }
    }
}
