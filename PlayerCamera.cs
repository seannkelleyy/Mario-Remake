using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;

namespace Mario
{
    public class PlayerCamera
    {
        public Matrix Transform { get; private set; }
        private IHero target;
        public PlayerCamera(IHero target)
        {
            this.target = target;
        }
        public void Follow()
        {
            var position = Matrix.CreateTranslation(-target.GetPosition().X - (target.GetRectangle().Width / 2),
                0,
                0);
            var offSet = Matrix.CreateTranslation(MarioRemake.ScreenWidth / 2,
                MarioRemake.ScreenHeight / 2,
                0);
            Transform = position * offSet;
        }
    }
}
