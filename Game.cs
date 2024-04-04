﻿using Mario.Global;
using Mario.Input;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Singletons;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Mario
{
    public class MarioRemake : Game
    {
        private PlayerCamera _camera;
        public static int ScreenWidth;
        public static int ScreenHeight;
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
            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / GameSettings.frameRate);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
            LevelLoader.Instance.LoadLevel($"../../../Levels/Sprint3.json");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            keyboardController.LoadCommands(this, gameContentManager.GetHero());
            _camera = new PlayerCamera(gameContentManager.GetHero());
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
                foreach (IEntityBase entity in gameContentManager.GetEntities())
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
                    keyboardController.LoadCommands(this, gameContentManager.GetHero());
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
            foreach (IEntityBase entity in gameContentManager.GetEntities())
            {
                entity.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
