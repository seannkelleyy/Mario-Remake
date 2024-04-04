using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

namespace Mario
{
    public class PlayerCamera
    {
        public Matrix Transform { get; private set; }
        private float cameraX;
        private IHero target;
        public PlayerCamera(IHero target)
        {
            this.target = target;
            var position = Matrix.CreateTranslation(-target.GetPosition().X - (target.GetRectangle().Width / 2),
                    0,
                    0);
            var offSet = Matrix.CreateTranslation(MarioRemake.ScreenWidth / 2,
                0,
                0);
            cameraX = target.GetPosition().X + (target.GetRectangle().Width / 2);
            Transform = position * offSet;
        }
        public void UpdatePosition()
        {
            if (target.GetPosition().X + (target.GetRectangle().Width / 2) > cameraX)
            {
                cameraX = target.GetPosition().X + (target.GetRectangle().Width / 2);
                var position = Matrix.CreateTranslation(-target.GetPosition().X - (target.GetRectangle().Width / 2),
                    0,
                    0);
                var offSet = Matrix.CreateTranslation(MarioRemake.ScreenWidth / 2,
                     0,
                    0);
                Transform = position * offSet;
            }
        }
        public float GetLeftEdge()
        {
            return cameraX - (MarioRemake.ScreenWidth / 2);
        }
    }
}
