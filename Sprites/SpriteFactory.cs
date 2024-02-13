using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Mario.Sprites;
using Mario.Interfaces;
using System.Reflection.Metadata;

public class SpriteFactory
{
    private Dictionary<string, int[]> spriteNumbers;
    private Texture2D[] spriteSheets;
    private static SpriteFactory instance = new SpriteFactory();
    public static SpriteFactory Instance
    {
        get
        {
            return instance;
        }
    }
    public SpriteFactory()
    {
        spriteNumbers = GlobalVariables.spriteNumbers;
    }
    public void LoadAllTextures(ContentManager content)
    {

        spriteSheets = new Texture2D[] {
            content.Load<Texture2D>("itemSpriteSheet"),
            content.Load<Texture2D>("tileSpriteSheet"),
            content.Load<Texture2D>("EnemySpriteSheet"),
            content.Load<Texture2D>("marioSpriteSheet")
        };
    }
    public ISprite CreateSprite(string type)
    {
        int[] spriteParameteres = spriteNumbers[type];
        return new Sprite(spriteSheets[spriteParameteres[6]], spriteParameteres);
    }
}
