using Microsoft.Xna.Framework;
using System.Data;

public static class GameSettings
{
    // Capitalized because they are static
    public static int FrameRate { get; set; }
    public static Vector2 CameraStarting { get; set; }
    public static Vector2 ScreenSize { get; set; }
    public static int InitialWindowHeight { get; set; } = 90;
    public static int WindowHeight { get; set; } = 470;
    public static bool IsDevelopment { get; set; }
}