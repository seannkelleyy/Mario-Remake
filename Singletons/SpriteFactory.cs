using Mario.Entities.Sprites;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Mario.Sprites
{
    public class SpriteFactory
    {
        private Dictionary<string, int[]> spriteNumbers;
        private Texture2D[] spriteSheets;
        private static SpriteFactory instance = new SpriteFactory();

        // This code follows the singleton pattern
        // When you need a SpriteFactory, you call SpriteFactory.Instance
        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        // This is a private constructor, so no one can create a new SpriteFactory
        private SpriteFactory()
        {
            spriteNumbers = SpriteVariables.spriteNumbers;
        }
        public void LoadAllTextures(ContentManager content)
        {
            spriteSheets = new Texture2D[] {
                content.Load<Texture2D>("itemSpriteSheet"),
                content.Load<Texture2D>("tileSpriteSheet"),
                content.Load<Texture2D>("enemySpriteSheet"),
                content.Load<Texture2D>("marioSpriteSheet"),
                content.Load<Texture2D>("projectileSpriteSheet")
            };
        }
        public ISprite CreateSprite(string type)
        {
            int[] spriteParameters = spriteNumbers[type];
            return new Sprite(spriteSheets[spriteParameters[6]], spriteParameters);
        }
    }
}
