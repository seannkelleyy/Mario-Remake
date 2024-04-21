using Mario.Global;
using Mario.Interfaces.Entities;
using Mario.Singletons;
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
            float cameraY = GameSettings.CameraStarting.Y; // Add this line

            if (target.GetPosition().Y > GameSettings.LevelTopHeight * GlobalVariables.BlockHeightWidth)
            {
                cameraY = GameSettings.UndergroundCamera.Y; // Modify this line
            }
            else if (target.GetPosition().X + (target.GetRectangle().Width / 2) > cameraX)
            {
                cameraX = target.GetPosition().X + (target.GetRectangle().Width / 2);
            }

            // Update the camera's Y position based on the target's Y position
            if (target.GetPosition().Y + (target.GetRectangle().Height / 2) > cameraY)
            {
                cameraY = target.GetPosition().Y + (target.GetRectangle().Height / 2);
            }

            var position = Matrix.CreateTranslation(-cameraX, -cameraY, 0); // Modify this line
            var offSet = Matrix.CreateTranslation(GameSettings.ScreenSize.X / 2, GameSettings.ScreenSize.Y / 2, 0);
            Transform = position * offSet;

            GlobalVariables.CameraLeftEdge = cameraX - (GameSettings.ScreenSize.X / 2);
            GlobalVariables.CameraBottomEdge = cameraY; // Modify this line
        }


        public void ResetCamera()
        {
            target = GameContentManager.Instance.GetHero();
            cameraX = GameSettings.CameraStarting.X;
            var position = Matrix.CreateTranslation(-GameSettings.CameraStarting.X,
                                   -GameSettings.CameraStarting.Y,
                                                      0);
            var offSet = Matrix.CreateTranslation(GameSettings.ScreenSize.X / 2,
                               GameSettings.ScreenSize.Y / 2,
                                              0);
            Transform = position * offSet;
        }
    }
}
