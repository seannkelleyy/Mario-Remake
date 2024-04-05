using Mario.Input;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

namespace Mario
{
    public class MarioRemake : Game
    {
        private PlayerCamera _camera;
        public static int ScreenWidth;
        public static int ScreenHeight;
        private GraphicsDeviceManager graphics;
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

            LevelLoader.Instance.Initialize(Content);

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            MediaManager.Instance.LoadContent(Content);
            GameSettingsLoader.LoadGameSettings("../../../Global/Settings/Data/GameSettings.json", "../../../Levels/Sprint3.json");

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / GameSettings.frameRate);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            LevelLoader.Instance.LoadLevel(GameSettingsLoader.LevelJsonFilePath);

            keyboardController.LoadCommands(this, GameContentManager.Instance.GetHero());
            MediaManager.Instance.PlayDefaultTheme();
            _camera = new PlayerCamera(GameContentManager.Instance.GetHero());

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            Logger.Instance.Close();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameSettings.isDevelopment)
                Logger.Instance.LogInformation($"----- Update @ {gameTime.ElapsedGameTime} -----");
            if (!GameStateManager.Instance.isPaused) // Normal update
            {
                foreach (IEntityBase entity in GameContentManager.Instance.GetEntities())
                {
                    entity.Update(gameTime);
                }
                keyboardController.Update(gameTime);
                _camera.UpdatePosition();
                base.Update(gameTime);

            }
            else if (GameStateManager.Instance.isResetting) // Updating when the level is resetting after the player dies
            {
                if (GameStateManager.Instance.resetTime < GameStateManager.maxResetTime)
                {
                    GameStateManager.Instance.SetResetTime(GameStateManager.Instance.resetTime + gameTime.ElapsedGameTime.TotalSeconds);
                }
                else
                {
                    GameStateManager.Instance.EndReset();
                    keyboardController = new KeyboardController();
                    keyboardController.LoadCommands(this, GameContentManager.Instance.GetHero());
                }
            }
            else
            { // Update during a pause
                keyboardController.UpdatePause(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: _camera.Transform);
            MediaManager.Instance.Draw(spriteBatch);
            foreach (IEntityBase entity in GameContentManager.Instance.GetEntities())
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
