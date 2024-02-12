using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Mario.Interfaces;
using GreenGame.Interfaces;
using Mario.Sprites;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> Commands;
        private Keys[] KeysPressed;
        private ISprite StillSpriteCrouch;
        private ISprite StillAnimatedSprite;
        private ISprite StillSpriteAttacking;
        private ISprite StillSpriteMoving;
        private ISprite MovingAnimatedSprite;
        private IItem ItemSprite;
        private IBlock BlockSprite;
        private IEnemy EnemySprite;


        public KeyboardController() {
            Commands = new Dictionary<Keys, ICommand>();
        }

        public void LoadCommands(MarioRemake game, ContentManager Content, SpriteBatch spriteBatch) {

            StillSpriteCrouch = new Sprite(Content.Load<Texture2D>("sprites/crouchMario"));
            StillSpriteAttacking = new Sprite(Content.Load<Texture2D>("sprites/attackMario"));
            StillAnimatedSprite = new Sprite(Content.Load<Texture2D>("sprites/animatedMario"), 2, 6);
            StillSpriteMoving = new Sprite(Content.Load<Texture2D>("sprites/jumpingMario"), yDistance: 50);
            MovingAnimatedSprite = new Sprite(Content.Load<Texture2D>("sprites/animatedMario"), 2, 6, xDistance: 100);

            SpriteState stillStateCrouch = new StillSpriteState(game, spriteBatch, StillSpriteCrouch);
            SpriteState stillStateAttacking = new StillSpriteState(game, spriteBatch, StillSpriteAttacking);
            SpriteState stillStateJump = new MovingStillSpriteState(game, spriteBatch, StillSpriteMoving);
            SpriteState movingRunningRightState = new AnimatedSpriteState(game, spriteBatch, MovingAnimatedSprite);
            SpriteState movingRunningLeftState = new AnimatedSpriteState(game, spriteBatch, MovingAnimatedSprite);

            ICommand DisplayStillJumpSpriteCommand = new DisplaySpriteCommand(stillStateJump, game);
            ICommand DisplayStillSpriteCrouchCommand = new DisplaySpriteCommand(stillStateCrouch, game);
            ICommand DisplayStillSpriteAttackingCommand = new DisplaySpriteCommand(stillStateAttacking, game);
            ICommand DisplayRunningRightCommand = new DisplaySpriteCommand(movingRunningRightState, game);
            ICommand DisplayRunningLeftCommand = new DisplaySpriteCommand(movingRunningLeftState, game);
            ICommand CycleNextItemCommand = ItemSprite.CycleNextItem();
            ICommand CyclePrevItemCommand = ItemSprite.CyclePrevItem();
            ICommand CycleNextBlockCommand = BlockSprite.CycleNextBlock();
            ICommand CyclePrevBlockCommand = BlockSprite.CyclePrevBlock();
            ICommand CycleNextEnemyCommand = EnemySprite.CycleNextEnemy();
            ICommand CyclePrevEnemyCommand = EnemySprite.CyclePrevEnemy();

            Commands.Add(Keys.Q, new QuitCommand(game));
            Commands.Add(Keys.R, new RestartCommand(game));
            Commands.Add(Keys.W, DisplayStillJumpSpriteCommand);
            Commands.Add(Keys.A, DisplayRunningLeftCommand);
            Commands.Add(Keys.S, DisplayStillSpriteCrouchCommand);
            Commands.Add(Keys.D, DisplayRunningRightCommand);
            Commands.Add(Keys.E, DisplayStillSpriteAttackingCommand);
            Commands.Add(Keys.I, CycleNextItemCommand);
            Commands.Add(Keys.U, CyclePrevItemCommand);
            Commands.Add(Keys.T, CyclePrevBlockCommand);
            Commands.Add(Keys.Y, CycleNextBlockCommand);
            Commands.Add(Keys.O, CyclePrevEnemyCommand);
            Commands.Add(Keys.P, CycleNextEnemyCommand);

        }

        public void Add(Keys key, ICommand command)
        {
            Commands.Add(key, command); 
        }

        public void Update() {
            KeyboardState state = Keyboard.GetState();
            foreach (Keys key in Commands.Keys)
            {
                if (state.IsKeyDown(key))
                {
                    Commands[key].Execute();
                }
            }
        }
    }
}
