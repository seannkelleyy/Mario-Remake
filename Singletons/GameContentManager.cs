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
		private SpriteFactory spriteFactory;
		private ISprite[] itemSprites;
        private IItem itemDisplay; 
		// Eventually we will have Mario and Enemies here as well

		public GameContentManager()
		{
		}

		public void Initialize()
		{
			spriteFactory = SpriteFactory.Instance;
		}

		public void Load(ContentManager content)
		{
            spriteFactory.LoadAllTextures(content);

            //Displays the item Sprites for sprint 2
			itemSprites = new ISprite[] { 
                spriteFactory.CreateSprite("fireFlower"), 
                spriteFactory.CreateSprite("coin"), 
                spriteFactory.CreateSprite("mushroom"), 
                spriteFactory.CreateSprite("star") 
            };

            itemDisplay = new Item(itemSprites, new Vector2(100,100));
		}

		public void Update(GameTime gameTime)
		{
            itemDisplay.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            itemDisplay.Draw(spriteBatch);
		}
	}
}

