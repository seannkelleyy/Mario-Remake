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
        private ISprite StillSpriteLeft;
        private ISprite StillSpriteRight;
        private ISprite StillSpriteCrouch;
        private ISprite StillAnimatedSprite;
        private ISprite StillSpriteAttacking;
        private ISprite StillSpriteMoving;
        private ISprite MovingAnimatedSprite;
        private IItem[] ItemSprites;
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

            KeyCommands = new Dictionary<Keys, ICommand>();
            MouseCommands = new Dictionary<string, ICommand>();

            KeyboardController = new KeyboardController(KeyCommands);
            MouseController = new MouseController(MouseCommands, Position);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("font");

            StillSpriteLeft = new Sprite(Content.Load<Texture2D>("sprites/mario"));
            StillSpriteRight = new Sprite(Content.Load<Texture2D>("sprites/mario"));
            StillSpriteCrouch = new Sprite(Content.Load<Texture2D>("sprites/crouchMario"));
            StillSpriteAttacking = new Sprite(Content.Load<Texture2D>("sprites/attackMario"));
            StillAnimatedSprite = new Sprite(Content.Load<Texture2D>("sprites/animatedMario"), 2, 6);
            StillSpriteMoving = new Sprite(Content.Load<Texture2D>("sprites/jumpingMario"), yDistance: 50);
            MovingAnimatedSprite = new Sprite(Content.Load<Texture2D>("sprites/animatedMario"), 2, 6, xDistance: 100);
            ItemSprites[0] = new Sprite(Content.Load<Texture2D>("sprites/item1"));
            ItemSprites[1] = new Sprite(Content.Load<Texture2D>("sprites/item2"));

            SpriteState stillStateLeft = new StillSpriteState(this, SpriteBatch, StillSpriteLeft);
            SpriteState stillStateRight = new StillSpriteState(this, SpriteBatch, StillSpriteRight);
            SpriteState stillStateCrouch = new StillSpriteState(this, SpriteBatch, StillSpriteCrouch);
            SpriteState stillStateAttacking = new StillSpriteState(this, SpriteBatch, StillSpriteAttacking);
            SpriteState stillStateJump = new MovingStillSpriteState(this, SpriteBatch, StillSpriteMoving);
            SpriteState movingRunningState = new AnimatedSpriteState(this, SpriteBatch, MovingAnimatedSprite);
            SpriteState itemSprite1 = new StillSpriteState(this, SpriteBatch, StillSpriteRight);

            ICommand DisplayStillSpriteLeftCommand = new DisplaySpriteCommand(stillStateLeft, this);
            ICommand DisplayStillSpriteRightCommand = new DisplaySpriteCommand(stillStateRight, this);
            ICommand DisplayStillJumpSpriteCommand = new DisplaySpriteCommand(stillStateJump, this);
            ICommand DisplayStillSpriteCrouchCommand = new DisplaySpriteCommand(stillStateCrouch, this);
            ICommand DisplayStillSpriteAttackingCommand = new DisplaySpriteCommand(stillStateAttacking, this);
            ICommand DisplayRunningCommand = new DisplaySpriteCommand(movingRunningState, this);
            ICommand CycleNextItemCommand

            KeyCommands[Keys.Q] = new QuitCommand(this);
            KeyCommands[Keys.R] = new RestartCommand(this);
            KeyCommands[Keys.W] = DisplayStillJumpSpriteCommand;
            KeyCommands[Keys.A] = DisplayStillSpriteLeftCommand;
            KeyCommands[Keys.S] = DisplayStillSpriteCrouchCommand;
            KeyCommands[Keys.D] = DisplayStillSpriteRightCommand;
            KeyCommands[Keys.Z] = DisplayStillSpriteAttackingCommand;
            KeyCommands[Keys.N] = DisplayStillSpriteAttackingCommand;
            KeyCommands[Keys.U] = 

            //MouseCommands["TopLeft"] = DisplayStillSpriteLeftCommand;
            //MouseCommands["TopRight"] = DisplayRunningCommand;
            //MouseCommands["BottomLeft"] = DisplayStillJumpSpriteCommand;
            //MouseCommands["BottomRight"] = DisplayMovingAnimatedCommand;

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
