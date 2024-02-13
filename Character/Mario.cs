<<<<<<< Updated upstream
﻿using Mario.Input;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class Mario : IPlayer
{
    private SpriteStates spriteStates;
    private Dictionary<string, Texture2D> sprites;
    private Vector2 position;
    private Texture2D currentSprite;
    private KeyboardController keyboardController;

    public Mario(Dictionary<string, Texture2D> sprites, KeyboardController keyboardController)
    {
        this.sprites = sprites;
        this.keyboardController = keyboardController;
        InitializeCommands();
        position = Vector2.Zero; // Starting position, adjust as needed
        currentSprite = sprites["Standing"]; // Default sprite
        spriteStates = SpriteStates.Standing; // Default state
    }

    private void InitializeCommands()
    {
        // Example of setting up commands, assuming these are implemented
        keyboardController.KeyCommands[Keys.Left] = new MoveLeftCommand(this);
        keyboardController.KeyCommands[Keys.Right] = new MoveRightCommand(this);
        // Add more command initializations here
    }

    public void Update(GameTime gameTime)
    {
        // Update Mario's state based on the current command executed
        // This could involve changing spriteStates and currentSprite based on the action
        keyboardController.Update(); // Process input and execute corresponding commands

        // Additional game logic here (e.g., physics, collisions)
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(currentSprite, position, Color.White);
    }

    // Implementing IPlayer interface methods, these methods are called by commands
    public void WalkLeft()
    {
        position.X -= 2; // Move left
        spriteStates = SpriteStates.WalkingLeft;
        currentSprite = sprites["WalkingLeft"];
    }

    public void WalkRight()
    {
        position.X += 2; // Move right
        spriteStates = SpriteStates.WalkingRight;
        currentSprite = sprites["WalkingRight"];
    }

    public void Jump()
    {
        // Jump logic here
        spriteStates = SpriteStates.Jumping;
        currentSprite = sprites["Jumping"];
    }

    public void Crouch()
    {
        // Crouch logic here
        spriteStates = SpriteStates.Crouching;
        currentSprite = sprites["Crouching"];
    }

}
=======
﻿using Mario.Input;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class Mario : IPlayer
{
    private SpriteStates spriteStates;
    private Dictionary<string, Texture2D> sprites;
    private Vector2 position;
    private Texture2D currentSprite;
    private KeyboardController keyboardController;

    public Mario(Dictionary<string, Texture2D> sprites, KeyboardController keyboardController)
    {
        this.sprites = sprites;
        this.keyboardController = keyboardController;
        InitializeCommands();
        position = Vector2.Zero; // Starting position, adjust as needed
        currentSprite = sprites["Standing"]; // Default sprite
        spriteStates = SpriteStates.Standing; // Default state
    }

    private void InitializeCommands()
    {
        // Example of setting up commands, assuming these are implemented
        keyboardController.KeyCommands[Keys.Left] = new MoveLeftCommand(this);
        keyboardController.KeyCommands[Keys.Right] = new MoveRightCommand(this);
        // Add more command initializations here
    }

    public void Update(GameTime gameTime)
    {
        // Update Mario's state based on the current command executed
        // This could involve changing spriteStates and currentSprite based on the action
        keyboardController.Update(); // Process input and execute corresponding commands

        // Additional game logic here (e.g., physics, collisions)
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(currentSprite, position, Color.White);
    }

    // Implementing IPlayer interface methods, these methods are called by commands
    public void WalkLeft()
    {
        position.X -= 2; // Move left
        spriteStates = SpriteStates.WalkingLeft;
        currentSprite = sprites["WalkingLeft"];
    }

    public void WalkRight()
    {
        position.X += 2; // Move right
        spriteStates = SpriteStates.WalkingRight;
        currentSprite = sprites["WalkingRight"];
    }

    public void Jump()
    {
        // Jump logic here
        spriteStates = SpriteStates.Jumping;
        currentSprite = sprites["Jumping"];
    }

    public void Crouch()
    {
        // Crouch logic here
        spriteStates = SpriteStates.Crouching;
        currentSprite = sprites["Crouching"];
    }

}
>>>>>>> Stashed changes
