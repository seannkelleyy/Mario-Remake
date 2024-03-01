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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
            gameContentManager.Load();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            keyboardController.LoadCommands(this, gameContentManager.GetHero());
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IEntityBase entity in gameContentManager.GetEntities())
            {
                entity.Update(gameTime);
            }
            keyboardController.Update(gameTime);
            base.Update(gameTime);
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
            String currentApplication = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentApplication);
            Environment.Exit(0);
        }
    }
}
