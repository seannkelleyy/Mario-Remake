using Mario.Entities.Character;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Mario.Singletons
{
    public class GameContentManager
    {
        private SpriteFactory spriteFactory;
        private static GameContentManager instance = new GameContentManager();
        private ArrayList entities;

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
            entities = new ArrayList();
        }

        public void Load()
        {
            // Will call level loader 
            entities.Add(new Hero(new Vector2(300, 100)));
        }
        public void add(IEntityBase entity) { 
            entities.Add(entity);
        }
        public void remove(IEntityBase entity) { 
            entities.Remove(entity);
        }
        public ArrayList GetEntities()
        {
            return entities;
        }
    }
}

