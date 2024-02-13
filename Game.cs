using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mario.Input;
using Mario.Interfaces;
using System.Collections.Generic;
using ICommand = Mario.Interfaces.ICommand;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;
        private Vector2 Position;

        public MarioRemake()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Position = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


            KeyboardController = new KeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardController.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();


            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
