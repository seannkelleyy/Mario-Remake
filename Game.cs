using Mario.Global;
using Mario.Input;
using Mario.Interfaces;
using Mario.Interfaces.Base;
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
        private bool isPaused;
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

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / GameSettings.frameRate);

            isPaused = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
            LevelLoader.Instance.LoadLevel($"../../../Levels/Sprint3.json");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            keyboardController.LoadCommands(this, gameContentManager.GetHero());
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            Logger.Instance.Close();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!isPaused)
            {
                Logger.Instance.LogInformation($"----------Update @ GameTime: {gameTime.TotalGameTime}-------------");
                foreach (IEntityBase entity in gameContentManager.GetEntities())
                {
                    entity.Update(gameTime);
                }
                keyboardController.Update(gameTime);

                base.Update(gameTime);

            } else
            {
                keyboardController.UpdatePause(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (IEntityBase entity in gameContentManager.GetEntities())
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Restarts the game
        public void Restart()
        {
            string currentApplication = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentApplication);
            Environment.Exit(0);
        }

        // Pauses or unpauses the game
        public void Pause()
        {
            isPaused = !isPaused;
        }
    }
}
