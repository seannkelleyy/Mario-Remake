using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public static class GameSettingsLoader
{
    public static string LevelJsonFilePath { get; set; }

    public static void LoadGameSettings(string jsonFilePath, string levelJsonFilePath)
    {
        LevelJsonFilePath = levelJsonFilePath;
        string jsonString = File.ReadAllText(jsonFilePath);
        var settings = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(jsonString);

        // Load GameSettings
        GameSettings.frameRate = Convert.ToInt32(settings["GameSettings"]["frameRate"]);
        GameSettings.isDevelopment = Convert.ToBoolean(settings["GameSettings"]["isDevelopment"]);

        // Load PhysicsSettings
        PhysicsSettings.gravity = Convert.ToSingle(settings["Physics"]["gravity"]);
        PhysicsSettings.friction = Convert.ToSingle(settings["Physics"]["friction"]);
        PhysicsSettings.jumpForce = Convert.ToSingle(settings["Physics"]["jumpForce"]);
        PhysicsSettings.maxVerticalSpeed = Convert.ToSingle(settings["Physics"]["maxVerticalSpeed"]);
        PhysicsSettings.maxRunSpeed = Convert.ToSingle(settings["Physics"]["maxRunSpeed"]);
        PhysicsSettings.runAcceleration = Convert.ToSingle(settings["Physics"]["runAcceleration"]);
        PhysicsSettings.enemySpeed = Convert.ToSingle(settings["Physics"]["enemySpeed"]);
        PhysicsSettings.koopaShellSpeed = Convert.ToSingle(settings["Physics"]["koopaShellSpeed"]);
        PhysicsSettings.regularJumpLimit = Convert.ToInt32(settings["Physics"]["regularJumpLimit"]);
        PhysicsSettings.smallJumpLimit = Convert.ToInt32(settings["Physics"]["smallJumpLimit"]);
        PhysicsSettings.fireballHorizontalSpeed = Convert.ToSingle(settings["Physics"]["fireballHorizontalSpeed"]);
        PhysicsSettings.fireballVerticalSpeed = Convert.ToSingle(settings["Physics"]["fireballVerticalSpeed"]);
        PhysicsSettings.fireballBounceForce = Convert.ToSingle(settings["Physics"]["fireballBounceForce"]);
        PhysicsSettings.fireballDeleteInterval = Convert.ToSingle(settings["Physics"]["fireballDeleteInterval"]);

        // Load CollisionSettings
        CollisionSettings.buffer = Convert.ToInt32(settings["Collisions"]["buffer"]);
        CollisionSettings.collisionPixelRadius = Convert.ToInt32(settings["Collisions"]["collisionPixelRadius"]);

        // Load entity setting
        EntitySettings.enemyDespawnTime = Convert.ToSingle(settings["Entity"]["enemyDespawnTime"]);
        EntitySettings.heroFlashDuration = Convert.ToSingle(settings["Entity"]["heroFlashDuration"]);
        EntitySettings.heroInvulnerabilityTime = Convert.ToSingle(settings["Entity"]["heroInvulnerabilityTime"]);
    }
}
