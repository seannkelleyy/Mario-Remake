using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario.Interfaces;
using System.Data.Common;
using System;

namespace Mario.Sprites
{
    // Class for sprites. Can either be an animated sprite or non animated sprite.
    public class Sprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int CurrentFrame = 0;
        private int TotalFrames;
        private  int size;
        private int SpriteSheetStartingX;
        private int SpriteSheetStartingY;
        private int width;
        private int height;
        float updateInterval;
        float elapsedSeconds;


        public Sprite(Texture2D texture, int[] spriteParams)
        {
            Texture = texture;
            SpriteSheetStartingX = spriteParams[0];
            SpriteSheetStartingY = spriteParams[1];
            width = spriteParams[2];
            height = spriteParams[3];    
            TotalFrames = spriteParams[4];
            this.size = spriteParams[5];
            updateInterval = .1f;
            elapsedSeconds = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Update the sprite every 1/30th of a second
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= updateInterval)
            {
                CurrentFrame = (CurrentFrame + 1) % TotalFrames;
                elapsedSeconds = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(SpriteSheetStartingX + width*CurrentFrame, SpriteSheetStartingY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)(location.Y), width*size, height*size);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
