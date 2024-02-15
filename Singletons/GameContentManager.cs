using System;
using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Singletons
{
	public class GameContentManager
	{
		private MarioRemake _game;
        private SpriteBatch SpriteBatch;
		private ISprite[] itemSprites;
        private IItem itemDisplay; 



		public GameContentManager(MarioRemake game)
		{
			_game = game;
		}

		public void Load(ContentManager content)
		{
            SpriteFactory.Instance.LoadAllTextures(content);

            //Displays the item Sprites for sprint 2
			itemSprites = new ISprite[] { 
                SpriteFactory.Instance.CreateSprite("fireFlower"), 
                SpriteFactory.Instance.CreateSprite("coin"), 
                SpriteFactory.Instance.CreateSprite("mushroom"), 
                SpriteFactory.Instance.CreateSprite("star") 
            };
            itemDisplay = new Item(itemSprites, new Vector2(100,100));
		}

		public void Update(GameTime gameTime)
		{
            itemDisplay.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            itemDisplay.Draw(SpriteBatch);
		}
	}
}

