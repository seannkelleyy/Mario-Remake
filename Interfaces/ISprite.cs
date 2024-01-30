﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Interfaces
{
    public interface ISprite
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position);

        void Update(GameTime gameTime);
    }
}