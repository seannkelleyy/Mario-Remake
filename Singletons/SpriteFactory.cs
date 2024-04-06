using Mario.Entities.Sprites;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Mario.Sprites
{
    public class SpriteFactory
    {
        // top left x pixel of sprite,
        // top left y pixel of the sprite, 
        // width of the sprite,
        // height of the sprite, 
        // number of frames for sprite, 
        // scalar size variable, 
        // spritesheet number
        private Dictionary<string, int[]> spriteNumbers;
        private SpriteFont font;
        private Texture2D[] spriteSheets;
        private static SpriteFactory instance = new SpriteFactory();

        public static SpriteFactory Instance => instance;

        private SpriteFactory() { }

        public void LoadAllTextures(ContentManager content, string pathToJson)
        {
            string jsonString = File.ReadAllText(pathToJson);
            spriteNumbers = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(jsonString);

            spriteSheets = new Texture2D[] {
                content.Load<Texture2D>("itemSpriteSheet"),
                content.Load<Texture2D>("tileSpriteSheet"),
                content.Load<Texture2D>("enemySpriteSheet"),
                content.Load<Texture2D>("marioSpriteSheet"),
                content.Load<Texture2D>("projectileSpriteSheet"),
                content.Load<Texture2D>("powerUpSpriteSheet")
            };

            font = content.Load<SpriteFont>("mainFont");
        }
        public ISprite CreateSprite(string type)
        {
            int[] spriteParameters = spriteNumbers[type];
            return new Sprite(spriteSheets[spriteParameters[6]], spriteParameters);
        }

        public SpriteFont GetMainFont()
        {
            return font;
        }
    }
}
