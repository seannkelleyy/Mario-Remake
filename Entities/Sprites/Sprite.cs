using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Sprites
{
    // Class for sprites. Can either be an animated sprite or non animated sprite.
    public class Sprite : ISprite
    {
        public Texture2D texture { get; set; }
        private int currentFrame = 0;
        private int totalFrames;
        private int size;
        private int spriteSheetStartingX;
        private int spriteSheetStartingY;
        private int width;
        private int height;
        float updateInterval;
        float elapsedSeconds;


        public Sprite(Texture2D texture, int[] spriteParams)
        {
            this.texture = texture;
            spriteSheetStartingX = spriteParams[0];
            spriteSheetStartingY = spriteParams[1];
            width = spriteParams[2];
            height = spriteParams[3];
            totalFrames = spriteParams[4];
            size = spriteParams[5];
            updateInterval = .2f;
            elapsedSeconds = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Update the sprite every 1/30th of a second
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= updateInterval)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
                elapsedSeconds = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(spriteSheetStartingX + width * currentFrame, spriteSheetStartingY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * size, height * size);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
