using Microsoft.Xna.Framework;
using static Mario.Global.CollisionVariables;

namespace Mario.Interfaces.Base
{
    public interface ICollideable
    {
        public Vector2 GetPosition();
        public void SetPosition(Vector2 position);
        public bool GetCollisionState(CollisionDirection direction);
        public void SetCollisionState(CollisionDirection direction, bool state);
        public Rectangle GetRectangle();
        public Vector2 GetVelocity();
    }
}
