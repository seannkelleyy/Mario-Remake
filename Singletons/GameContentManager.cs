using Mario.Entities.Character;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private SpriteFactory spriteFactory;
        private IHero mario;
        private static GameContentManager instance = new GameContentManager();

        // This code follows the singleton pattern
        // When you need a GCM, you call GameContentManager.Instance
        public static GameContentManager Instance
        {
            get
            {
                return instance;
            }
        }

        // This is a private constructor, so no one can create a new GameContentManager
        private GameContentManager() { }

        public void Initialize()
        {
            spriteFactory = SpriteFactory.Instance;
        }

        public void Load()
        {
            // Will call level loader 
            mario = new Hero(new Vector2(300, 400));
        }

        public IEntityBase[] GetEntities()
        {
            IEntityBase[] entities = new IEntityBase[1];
            entities[0] = mario;
            return entities;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Draw(spriteBatch);
        }
    }
}

