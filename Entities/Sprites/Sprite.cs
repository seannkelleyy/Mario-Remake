using Mario.Global;
using Mario.Interfaces.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Sprites
{
    // Class for sprites. Can either be an animated sprite or non animated sprite.
    public class Sprite : ISprite
    {
        private Texture2D texture { get; set; }
        private int currentFrame = 0;
        private int totalFrames;
        private int size;
        private int spriteSheetStartingX;
        private int spriteSheetStartingY;
        private int width;
        private int height;
        private float elapsedSeconds = 0;


        public Sprite(Texture2D texture, int[] spriteParams)
        {
            this.texture = texture;
            spriteSheetStartingX = spriteParams[0];
            spriteSheetStartingY = spriteParams[1];
            width = spriteParams[2];
            height = spriteParams[3];
            totalFrames = spriteParams[4];
            size = spriteParams[5];
        }

        public void Update(GameTime gameTime)
        {
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedSeconds >= GlobalVariables.SpriteUpdateInterval)
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

        public Vector2 GetVector()
        {
            return new Vector2(width, height);
        }

    }
}
