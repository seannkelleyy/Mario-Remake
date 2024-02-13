using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Input;
using Mario.Interfaces;

namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;
<<<<<<< Updated upstream
=======
        private IController MouseController;
        private Texture2D texture;
        private Dictionary<Keys, ICommand> KeyCommands;
        private Dictionary<string, ICommand> MouseCommands;
        private SpriteFont Font;
        private Vector2 Position;
        private ISprite StillSprite;
        private ISprite MovingStillSprite;
        private ISprite StillAnimatedSprite;
        private ISprite MovingAnimatedSprite;
        public SpriteState CurrentSprite { get; set; }
>>>>>>> Stashed changes

        public MarioRemake()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            KeyboardController = new KeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
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
