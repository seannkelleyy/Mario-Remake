using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Mario.Sprites;
using Mario.Interfaces;

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
        spriteNumbers = new Dictionary<string, int[]> {
            { "fireFlower", new int[] { 0, 0, 16, 16, 4, 1, 0 } },
            { "star", new int[] { 0, 16, 16, 16, 4, 1, 0 } },
            { "coin", new int[] { 0, 32, 16, 16, 4, 1, 0 } },
            { "mushroom", new int[] { 0, 48, 16, 16, 1, 1, 0 } },
            { "1up", new int[] { 0, 64, 16, 16, 1, 1, 0 } },
            { "questionMarkTile", new int[] { 0, 0, 16, 16, 3, 1, 1 } },
            { "brickTile", new int[] { 0, 16, 16, 16, 1, 1, 1 } },
            { "emptyTile", new int[] { 16, 16, 16, 16, 1, 1, 1 } },
            { "rockTile", new int[] { 32, 16, 16, 16, 1, 1, 1 } },
            { "stoneTile", new int[] { 0, 32, 16, 16, 1, 1, 1 } },
            { "pipeTile", new int[] { 16, 32, 32, 32, 1, 1, 1 } },
            { "goomba", new int[] { 0, 0, 16, 16, 2, 1, 2 } },
            { "rightKoopa", new int[] { 0, 16, 16, 24, 2, 1, 2 } },
            { "leftKoopa", new int[] { 0, 40, 16, 24, 2, 1, 2 } },
            { "rightJumpMario", new int[] { 0, 0, 16, 16, 1, 1, 3 } },
            { "rightRunMario", new int[] { 16, 0, 16, 16, 3, 1, 3 } },
            { "rightStandMario", new int[] { 64, 0, 16, 16, 1, 1, 3 } },
            { "leftJumpMario", new int[] { 0, 16, 16, 16, 1, 1, 3 } }};
    }
    public void LoadAllTextures(ContentManager content)
    {

        spriteSheets = new Texture2D[] { content.Load<Texture2D>("itemSpriteSheet"), content.Load<Texture2D>("tileSpriteSheet"), content.Load<Texture2D>("enemySpriteSheet"), content.Load<Texture2D>("marioSpriteSheet") };
    }
    public ISprite CreateSprite(string type)
    {
        int[] spriteParameteres = spriteNumbers[type];
        return new Sprite(spriteSheets[spriteParameteres[6]], ref spriteParameteres);
    }
}
