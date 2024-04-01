using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SpriteVariables
{
    // top left x pixel of sprite,
    // top left y pixel of the sprite, 
    // width of the sprite,
    // height of the sprite, 
    // number of frames for sprite, 
    // scalar size variable, 
    // spritesheet number

    public static Dictionary<string, int[]> spriteNumbers;

    public SpriteVariables() { }

    public static void LoadSpriteNumbers(string json)
    {
        string jsonString = File.ReadAllText(json);
        spriteNumbers = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(jsonString);
    }
}
