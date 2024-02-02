using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mario.Interfaces;

namespace Mario.Sprites
{
    // Class for sprites. Can either be an animated sprite or non animated sprite.
    public class Sprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame = 0;
        private int TotalFrames;
        private int YDistance;
        private int MaxYDistance;
        private bool YDirection = true;
        private int XDistance;
        private int MaxXDistance;
        private bool XDirection = true;

        public Sprite(Texture2D texture, int rows = 1, int columns = 1, int yDistance = 0, int xDistance = 0)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            TotalFrames = Rows * Columns;
            MaxYDistance = yDistance;
            MaxXDistance = xDistance;

        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Texture.Height, Texture.Width);
        }

        public void Update(GameTime gameTime)
        {
            // Update the sprite every 1/30th of a second
            float updateInterval = 1.0f / 30.0f;
            float elapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedSeconds >= updateInterval)
            {
                CurrentFrame = (CurrentFrame + 1) % TotalFrames;

                if (MaxYDistance > 0)
                {
                    UpdateDistanceAndDirection(ref YDistance, ref YDirection, MaxYDistance);
                }

                if (MaxXDistance > 0)
                {
                    UpdateDistanceAndDirection(ref XDistance, ref XDirection, MaxXDistance);
                }
            }
        }

        // Helper function to update the distance, since the code for either distnace was pretty much the same.
        // I pass the values by ref so that it updates the original value.
        private void UpdateDistanceAndDirection(ref int distance, ref bool direction, int maxDistance)
        {
            if (direction)
            {
                distance++;
                if (distance == maxDistance)
                {
                    direction = false;
                }
            }
            else
            {
                distance--;
                if (distance == 0)
                {
                    direction = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X + XDistance, (int)(location.Y + YDistance), width, height);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
