using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Mario.Input
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, Action> Commands;

        // We will probably just instantiate these here for Spint 2 purposes,
        // but they will be gone after that.
        private IItem item;
        private IBlock block;
        private IHero mario;
        private IEnemyCycle enemy;
        private Keys[] keysPressed;
        float updateInterval = 0.1f;
        float elapsedSeconds = 0;


        public KeyboardController()
        {
            Commands = new Dictionary<Keys, Action>();
        }

        // NOTE: When we start saving the state for the character, we will pass in the GameContentManager
        // to assign the functions to call when keys are pressed.
        public void LoadCommands(MarioRemake game, IEntityBase[] entities)
        {

            item = (IItem)entities[0];
            block = (IBlock)entities[1];
            mario = (IHero)entities[2];
            enemy = (IEnemyCycle)entities[3];

            // System commands
            Commands.Add(Keys.Q, new Action(game.Exit));
            Commands.Add(Keys.R, new Action(game.Restart));

            // Hero/Player Commands
            Commands.Add(Keys.W, new Action(() =>
            {
                // This allows for mario to move up and to the left or right
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    mario.Jump();
                    mario.WalkLeft();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    mario.Jump();
                    mario.WalkRight();
                }
                else
                {
                    mario.Jump();
                }
            }));

            Commands.Add(Keys.A, new Action(mario.WalkLeft));
            Commands.Add(Keys.S, new Action(() =>
            {
                // This will change after sprint 2, we just wanted to be able to move mario around
                // This allows for mario to move down and to the left or right
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    mario.Crouch();
                    mario.WalkLeft();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    mario.Crouch();
                    mario.WalkRight();
                }
                else
                {
                    mario.Crouch();
                }
            }));
            Commands.Add(Keys.D, new Action(mario.WalkRight));
            Commands.Add(Keys.E, new Action(mario.TakeDamage));

            // Non-moving entity Cycle Commands
            Commands.Add(Keys.I, new Action(item.CycleItemNext));
            Commands.Add(Keys.U, new Action(item.CycleItemPrev));
            Commands.Add(Keys.T, new Action(block.CycleBlockNext));
            Commands.Add(Keys.Y, new Action(block.CycleBlockPrev));

            // Moving entity Cycle Commands
            Commands.Add(Keys.O, new Action(enemy.CycleEnemyNext));
            Commands.Add(Keys.P, new Action(enemy.CycleEnemyPrev));
        }

        public void Add(Keys key, Action action)
        {
            Commands.Add(key, action);
        }

        public void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= updateInterval)
            {
                elapsedSeconds = 0;
                keysPressed = Keyboard.GetState().GetPressedKeys();
                foreach (Keys key in keysPressed)
                {
                    if (Commands.ContainsKey(key))
                    {
                        Commands[key].Invoke();
                    }
                }
            }
        }
    }
}
