﻿using Microsoft.Xna.Framework;

public static class GameSettings
{
    // Capitalized because they are static
    public static int FrameRate { get; set; }
    public static Vector2 CameraStarting { get; set; }
    public static Vector2 ScreenSize { get; set; }
    public static bool IsDevelopment { get; set; }
    public static int LevelTopHeight { get; set; }
    public static Vector2 UndergroundCamera { get; set; }
    public static float LevelEnd { get; set; }
}