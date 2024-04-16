using Mario.Global;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

namespace Mario.Input
{
    public class PlayerCamera
    {
        public Matrix Transform { get; private set; }
        private float cameraX;
        private IHero target;
        public PlayerCamera(IHero target)
        {
            this.target = target;
            var position = Matrix.CreateTranslation(-GameSettings.CameraStarting.X,
                    -GameSettings.CameraStarting.Y,
                    0);
            var offSet = Matrix.CreateTranslation(GameSettings.ScreenSize.X / 2,
                GameSettings.ScreenSize.Y / 2,
                0);
            cameraX = GameSettings.CameraStarting.X;
            Transform = position * offSet;
        }
        public void UpdatePosition()
        {
            if (target.GetPosition().X + (target.GetRectangle().Width / 2) > cameraX)
            {
                cameraX = target.GetPosition().X + (target.GetRectangle().Width / 2);
                var position = Matrix.CreateTranslation(-target.GetPosition().X - (target.GetRectangle().Width / 2),
                    -48,
                    0);
                var offSet = Matrix.CreateTranslation(GameSettings.ScreenSize.X / 2,
                     GameSettings.ScreenSize.Y / 2,
                    0);
                Transform = position * offSet;
            }
            GlobalVariables.CameraLeftEdge = cameraX - (GameSettings.ScreenSize.X / 2);
            GlobalVariables.CameraBottomEdge = target.GetPosition().Y + (target.GetRectangle().Height / 2);
        }

        public void ResetCamera()
        {
            var position = Matrix.CreateTranslation(-GameSettings.CameraStarting.X,
                                 -48,
                                                      0);
            var offSet = Matrix.CreateTranslation(GameSettings.ScreenSize.X / 2,
                               GameSettings.ScreenSize.Y / 2,
                                              0);
            Transform = position * offSet;

            GlobalVariables.CameraLeftEdge = GameSettings.CameraStarting.X;
            GlobalVariables.CameraBottomEdge = target.GetPosition().Y + (target.GetRectangle().Height / 2);
        }
    }
}
