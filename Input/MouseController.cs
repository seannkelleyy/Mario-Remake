using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint0.Input
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
