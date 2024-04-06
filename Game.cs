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
        private PlayerCamera camera;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private IController keyboardController;
        private HeadsUpDisplay HUD;
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

            GameSettingsLoader.LoadGameSettings("../../../Global/Settings/Data/GameSettings.json", "../../../Levels/1-1.json", graphics);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            MediaManager.Instance.LoadContent(Content);

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / GameSettings.FrameRate);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            LevelLoader.Instance.LoadLevel(GameSettingsLoader.LevelJsonFilePath);

            HUD = new HeadsUpDisplay();

            keyboardController.LoadCommands(this, GameContentManager.Instance.GetHero());
            MediaManager.Instance.PlayDefaultTheme();
            camera = new PlayerCamera(GameContentManager.Instance.GetHero());

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
            Logger.Instance.Close();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameSettings.IsDevelopment)
                Logger.Instance.LogInformation($"----- Update @ {gameTime.ElapsedGameTime} -----");
            if (!GameStateManager.Instance.isPaused) // Normal update
            {
                foreach (IEntityBase entity in GameContentManager.Instance.GetEntities())
                {
                    entity.Update(gameTime);
                }
                keyboardController.Update(gameTime);
                camera.UpdatePosition();
                base.Update(gameTime);
                HUD.Update(gameTime, camera);
            }
            else if (GameStateManager.Instance.isResetting) // Updating when the level is resetting after the player dies
            {
                if (GameStateManager.Instance.resetTime < GlobalVariables.MaxResetTime)
                {
                    GameStateManager.Instance.SetResetTime(GameStateManager.Instance.resetTime + gameTime.ElapsedGameTime.TotalSeconds);
                }
                else if (GameStateManager.Instance.resetTime >= GlobalVariables.MaxResetTime)
                {
                    GameStateManager.Instance.EndReset(camera);
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

            spriteBatch.Begin(transformMatrix: camera.Transform);
            MediaManager.Instance.Draw(spriteBatch);
            foreach (IEntityBase entity in GameContentManager.Instance.GetEntities())
            {
                entity.Draw(spriteBatch);
            }
            HUD.Draw(spriteBatch, SpriteFactory.Instance.GetMainFont());
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
