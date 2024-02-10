using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Mario.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Input
{
    public class MouseController : IController
    {
        private Dictionary<string, ICommand> Commands;
        private MouseState MouseState;
        private Vector2 Viewport;

        public MouseController(Dictionary<string, ICommand> commands, Vector2 viewport)
        {
            Commands = commands;
            MouseState = new MouseState();
            Viewport = viewport;
        }
        public void Add(Keys key, ICommand command)
        {
            // Implement when needed
        }

        public void LoadCommands(MarioRemake game, ContentManager content, SpriteBatch spriteBatch)
        {
            // Implement when needed
        }
        public void Update()
        {
            MouseState = Mouse.GetState();

            if (MouseState.LeftButton == ButtonState.Pressed || MouseState.RightButton == ButtonState.Pressed)
            {
                bool isTopHalf = MouseState.Y < Viewport.Y / 2;
                bool isRightHalf = MouseState.X > Viewport.X / 2;

                string quadrant = GetQuadrant(isTopHalf, isRightHalf);

                if (MouseState.RightButton == ButtonState.Pressed)
                {
                    Environment.Exit(0);
                }
                else if (Commands.ContainsKey(quadrant))
                {
                    Commands[quadrant].Execute();
                }
            }
        }

        private string GetQuadrant(bool isTopHalf, bool isRightHalf)
        {
            if (isTopHalf && !isRightHalf)
            {
                return "TopLeft";
            }
            else if (isTopHalf && isRightHalf)
            {
                return "TopRight";
            }
            else if (!isTopHalf && !isRightHalf)
            {
                return "BottomLeft";
            }
            else // !isTopHalf && isRightHalf
            {
                return "BottomRight";
            }
        }
    }
}
