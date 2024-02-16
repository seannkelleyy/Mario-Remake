using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Input;
using Mario.Interfaces;
using Mario.Sprites;
namespace Mario
{
    public class MarioRemake : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private IController KeyboardController;
        private ISprite[] itemSprites;
        private IItem itemDisplay; 
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
            //Displays the item Sprites for sprint 2
            itemSprites = new ISprite[] { 
                SpriteFactory.Instance.CreateSprite("fireFlower"), 
                SpriteFactory.Instance.CreateSprite("coin"), 
                SpriteFactory.Instance.CreateSprite("mushroom"), 
                SpriteFactory.Instance.CreateSprite("star") 
            };
            itemDisplay = new Item(itemSprites, new Vector2(100,100));
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardController.Update();
            base.Update(gameTime);
            itemDisplay.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();
            itemDisplay.Draw(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
