using Mario.Entities.Character;
using Mario.Entities.EnemyCycle;
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
		private ISprite[] goombaSprites;
		private ISprite[] koopaSprites;
		private IHero marioDisplay;
		private IEnemyCycle goombaDisplay;
		private IEnemyCycle koopaDisplay;
        private IItem itemDisplay; 
		private IBlock blockDisplay;

		public GameContentManager() { }

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

			goombaSprites = new ISprite[]
			{
				spriteFactory.CreateSprite("goomba")
			};

			koopaSprites = new ISprite[]
			{
				spriteFactory.CreateSprite("rightKoopa"),
				spriteFactory.CreateSprite("leftKoopa")
			};

            itemDisplay = new Item(itemSprites);
			blockDisplay = new Block(blockSprites);
			goombaDisplay = new EnemyCycle(goombaSprites);
			koopaDisplay = new EnemyCycle(koopaSprites);
			marioDisplay = new Hero();
		}

		public void Update(GameTime gameTime)
		{
			marioDisplay.Update(gameTime);
            itemDisplay.Update(gameTime);
			blockDisplay.Update(gameTime);
			goombaDisplay.Update(gameTime);
			koopaDisplay.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            itemDisplay.Draw(spriteBatch, new Vector2(100, 100));
			blockDisplay.Draw(spriteBatch, new Vector2(200, 100));
			marioDisplay.Draw(spriteBatch, new Vector2(300, 100));
			goombaDisplay.Draw(spriteBatch, new Vector2(400, 100));
			koopaDisplay.Draw(spriteBatch, new Vector2(500, 100));
		}
	}
}

