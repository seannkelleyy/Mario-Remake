using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mario.Input;
using Mario.Interfaces;
using Mario.Sprites;
using System.Collections.Generic;
using ICommand = Mario.Interfaces.ICommand;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;
        private IController MouseController;
        private Dictionary<Keys, ICommand> KeyCommands;
        private Dictionary<string, ICommand> MouseCommands;
        private SpriteFont Font;
        private Vector2 Position;
        private ISprite StillSprite;
        private ISprite MovingStillSprite;
        private ISprite StillAnimatedSprite;
        private ISprite MovingAnimatedSprite;
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

            KeyCommands = new Dictionary<Keys, ICommand>();
            MouseCommands = new Dictionary<string, ICommand>();

            KeyboardController = new KeyboardController(KeyCommands);
            MouseController = new MouseController(MouseCommands, Position);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            StillSprite = SpriteFactory.Instance.CreateSprite("rightStandMario");
            MovingStillSprite = SpriteFactory.Instance.CreateSprite("rightJumpMario");
            StillAnimatedSprite = SpriteFactory.Instance.CreateSprite("rightRunMario");
            MovingAnimatedSprite = SpriteFactory.Instance.CreateSprite("rightRunMario");

            SpriteState stillState = new StillSpriteState(this, SpriteBatch, StillSprite);
            SpriteState movingStillState = new MovingStillSpriteState(this, SpriteBatch, MovingStillSprite);
            SpriteState animatedState = new AnimatedSpriteState(this, SpriteBatch, StillAnimatedSprite);
            SpriteState movingAnimatedState = new MovingAnimatedSpriteState(this, SpriteBatch, MovingAnimatedSprite);

            ICommand DisplayStillSpriteCommand = new DisplaySpriteCommand(stillState, this);
            ICommand DisplayMovingStillSpriteCommand = new DisplaySpriteCommand(movingStillState, this);
            ICommand DisplayAnimatedCommand = new DisplaySpriteCommand(animatedState, this);
            ICommand DisplayMovingAnimatedCommand = new DisplaySpriteCommand(movingAnimatedState, this);

            KeyCommands[Keys.NumPad0] = new QuitCommand(this);
            KeyCommands[Keys.NumPad1] = DisplayStillSpriteCommand;
            KeyCommands[Keys.NumPad2] = DisplayAnimatedCommand;
            KeyCommands[Keys.NumPad3] = DisplayMovingStillSpriteCommand;
            KeyCommands[Keys.NumPad4] = DisplayMovingAnimatedCommand;

            MouseCommands["TopLeft"] = DisplayStillSpriteCommand;
            MouseCommands["TopRight"] = DisplayAnimatedCommand;
            MouseCommands["BottomLeft"] = DisplayMovingStillSpriteCommand;
            MouseCommands["BottomRight"] = DisplayMovingAnimatedCommand;

            CurrentSprite = stillState; // Set the initial sprite state

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
