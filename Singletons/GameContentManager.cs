using Mario.Character;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
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
		private ISprite[] blockSprites;
		private IHero Mario;
		private IEnemy[] enemy;
        private IItem itemDisplay; 
		private IBlock blockDisplay;
		// Eventually we will have Mario and Enemies here as well

		public GameContentManager()
		{
		}

		public void Initialize()
		{
			spriteFactory = SpriteFactory.Instance;
		}

		public void Load(ContentManager content, SpriteBatch spriteBatch)
		{
            spriteFactory.LoadAllTextures(content);

            //Displays the item Sprites for sprint 2
			itemSprites = new ISprite[] { 
                spriteFactory.CreateSprite("fireFlower"), 
                spriteFactory.CreateSprite("coin"), 
                spriteFactory.CreateSprite("mushroom"), 
                spriteFactory.CreateSprite("star") 
            };

			blockSprites = new ISprite[]
			{
                spriteFactory.CreateSprite("brickTile"), 
                spriteFactory.CreateSprite("emptyTile"), 
                spriteFactory.CreateSprite("rockTile"), 
                spriteFactory.CreateSprite("stoneTile"),
				spriteFactory.CreateSprite("pipeTile"),
            };	

            itemDisplay = new Item(itemSprites, new Vector2(100,100));
			blockDisplay = new Block(blockSprites);

			Mario = new Hero(content, spriteBatch, new Vector2(200, 300));
		}

		public void Update(GameTime gameTime)
		{
			Mario.Update(gameTime);
            itemDisplay.Update(gameTime);
			blockDisplay.Update(gameTime);
		
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            itemDisplay.Draw(spriteBatch);
			blockDisplay.Draw(spriteBatch, new Vector2(200, 200));
			Mario.Draw();
		}
	}
}

