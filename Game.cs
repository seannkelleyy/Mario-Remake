using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mario.Input;
using Mario.Interfaces;
using Mario.Sprites;
using System.Collections.Generic;
using ICommand = Mario.Interfaces.ICommand;
using GreenGame.Interfaces;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;
        private IController MouseController;
        private Dictionary<string, ICommand> MouseCommands;
        private SpriteFont Font;
        private Vector2 Position;
        private ISprite StillSpriteRight;
        // This uses the state design pattern. 
        public SpriteState CurrentSprite { get; set; }

        public MarioRemake()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Position = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            KeyboardController = new KeyboardController();

            StillSpriteRight = new Sprite(Content.Load<Texture2D>("sprites/mario"));

            SpriteState stillStateRight = new StillSpriteState(this, SpriteBatch, StillSpriteRight);

            KeyboardController.LoadCommands(this, Content, SpriteBatch);

            CurrentSprite = stillStateRight; // Set the initial sprite state

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardController.Update();
            MouseController.Update();

            CurrentSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();

            CurrentSprite.Draw(Position / 2);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
