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
		private ISprite[] enemySprites;
		private IHero mario;
		private IEnemyCycle enemy;
        private IItem item; 
		private IBlock block;

		public GameContentManager() { }

		public void Initialize()
		{
			spriteFactory = SpriteFactory.Instance;
		}

		public void Load()
		{
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

			enemySprites = new ISprite[]
			{
				spriteFactory.CreateSprite("goomba"),
				spriteFactory.CreateSprite("rightKoopa"),
				spriteFactory.CreateSprite("leftKoopa")
			};


            item = new Item(itemSprites);
			block = new Block(blockSprites);
			enemy = new EnemyCycle(enemySprites);
			mario = new Hero();
		}

		public IEntityBase[] GetEntities()
		{
			IEntityBase[] entities = new IEntityBase[4];
			entities[0] = item;
			entities[1] = block;
			entities[2] = mario;
			entities[3] = enemy;
            return entities;
        }

		public void Update(GameTime gameTime)
		{
			mario.Update(gameTime);
            item.Update(gameTime);
			block.Update(gameTime);
			enemy.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
            item.Draw(spriteBatch, new Vector2(100, 100));
			block.Draw(spriteBatch, new Vector2(200, 100));
			mario.Draw(spriteBatch, new Vector2(300, 100));
			enemy.Draw(spriteBatch, new Vector2(400, 100));
		}
	}
}

