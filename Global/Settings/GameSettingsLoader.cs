using Mario.Global.Settings;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class GameSettingsLoader
{
    public static string LevelJsonFilePath { get; set; }

    public static void LoadGameSettings(string jsonFilePath, string levelJsonFilePath, GraphicsDeviceManager graphics)
    {
        LevelJsonFilePath = levelJsonFilePath;
        string jsonString = File.ReadAllText(jsonFilePath);
        var settings = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(jsonString);

        // Load GameSettings
        GameSettings.FrameRate = Convert.ToInt32(settings["GameSettings"]["frameRate"]);
        GameSettings.CameraStarting = new Vector2(Convert.ToSingle(settings["GameSettings"]["cameraStartingX"]), Convert.ToSingle(settings["GameSettings"]["cameraStartingY"]));
        GameSettings.ScreenSize = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
        GameSettings.IsDevelopment = Convert.ToBoolean(settings["GameSettings"]["isDevelopment"]);
        GameSettings.LevelTopHeight = Convert.ToInt32(settings["GameSettings"]["levelTopHeight"]);
        GameSettings.UndergroundCamera = new Vector2(Convert.ToSingle(settings["GameSettings"]["UndergroundCameraX"]), Convert.ToSingle(settings["GameSettings"]["UndergroundCameraY"]));
        GameSettings.LevelEnd = Convert.ToSingle(settings["GameSettings"]["levelEnd"]);


        // Load PhysicsSettings
        PhysicsSettings.Gravity = Convert.ToSingle(settings["Physics"]["gravity"]);
        PhysicsSettings.Friction = Convert.ToSingle(settings["Physics"]["friction"]);
        PhysicsSettings.JumpForce = Convert.ToSingle(settings["Physics"]["jumpForce"]);
        PhysicsSettings.MaxVerticalSpeed = Convert.ToSingle(settings["Physics"]["maxVerticalSpeed"]);
        PhysicsSettings.MaxRunSpeed = Convert.ToSingle(settings["Physics"]["maxRunSpeed"]);
        PhysicsSettings.RunAcceleration = Convert.ToSingle(settings["Physics"]["runAcceleration"]);
        PhysicsSettings.EnemySpeed = Convert.ToSingle(settings["Physics"]["enemySpeed"]);
        PhysicsSettings.KoopaShellSpeed = Convert.ToSingle(settings["Physics"]["koopaShellSpeed"]);
        PhysicsSettings.RegularJumpLimit = Convert.ToInt32(settings["Physics"]["regularJumpLimit"]);
        PhysicsSettings.SmallJumpLimit = Convert.ToInt32(settings["Physics"]["smallJumpLimit"]);
        PhysicsSettings.MinimumJumpLimit = Convert.ToInt32(settings["Physics"]["minimumJumpLimit"]);
        PhysicsSettings.StarJumpLimit = Convert.ToInt32(settings["Physics"]["starJumpLimit"]);
        PhysicsSettings.DecelerationFactor = Convert.ToSingle(settings["Physics"]["decelerationFactor"]);
        PhysicsSettings.FireballHorizontalSpeed = Convert.ToSingle(settings["Physics"]["fireballHorizontalSpeed"]);
        PhysicsSettings.FireballVerticalAcceleration = Convert.ToSingle(settings["Physics"]["fireballVerticalAcceleration"]);
        PhysicsSettings.FireballBounceForce = Convert.ToSingle(settings["Physics"]["fireballBounceForce"]);
        PhysicsSettings.FireballDeleteInterval = Convert.ToSingle(settings["Physics"]["fireballDeleteInterval"]);

        // Load CollisionSettings
        CollisionSettings.Buffer = Convert.ToInt32(settings["Collisions"]["buffer"]);
        CollisionSettings.CollisionPixelRadius = Convert.ToInt32(settings["Collisions"]["collisionPixelRadius"]);

        // Load entity setting
        EntitySettings.EnemyDespawnTime = Convert.ToSingle(settings["Entity"]["enemyDespawnTime"]);
        EntitySettings.KoopaShellTime = Convert.ToSingle(settings["Entity"]["koopaShellTime"]);
        EntitySettings.HeroFlashDuration = Convert.ToSingle(settings["Entity"]["heroFlashDuration"]);
        EntitySettings.HeroInvulnerabilityTime = Convert.ToSingle(settings["Entity"]["heroInvulnerabilityTime"]);
        EntitySettings.HeroAttackTime = Convert.ToSingle(settings["Entity"]["heroAttackTime"]);
        EntitySettings.HeroAnimationLength = Convert.ToSingle(settings["Entity"]["heroAnimationLength"]);
        EntitySettings.HeroStarTimer = Convert.ToSingle(settings["Entity"]["heroStarTimer"]);

        //Scores
        ScoreSettings.KoopaScore = Convert.ToInt32(settings["Scores"]["koopaScore"]);
        ScoreSettings.GoombaScore = Convert.ToInt32(settings["Scores"]["goombaScore"]);
        ScoreSettings.PiranhaScore = Convert.ToInt32(settings["Scores"]["piranhaScore"]);
        ScoreSettings.BulletScore = Convert.ToInt32(settings["Scores"]["bulletScore"]);
        ScoreSettings.CoinScore = Convert.ToInt32(settings["Scores"]["coinScore"]);
        ScoreSettings.FireFlowerScore = Convert.ToInt32(settings["Scores"]["fireFlowerScore"]);
        ScoreSettings.StarScore = Convert.ToInt32(settings["Scores"]["starScore"]);
        ScoreSettings.MushroomScore = Convert.ToInt32(settings["Scores"]["mushroomScore"]);
        ScoreSettings.TimeScore = Convert.ToInt32(settings["Scores"]["timeScore"]);
        ScoreSettings.FlagScore = Convert.ToInt32(settings["Scores"]["flagScore"]);
        ScoreSettings.BreakBlockScore = Convert.ToInt32(settings["Scores"]["breakBlockScore"]);
    }
}
