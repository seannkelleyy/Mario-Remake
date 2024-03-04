using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Mario.Global.CollisionVariables;

namespace Mario.Interfaces.Base
{
    public interface ICollideable
    {
        public Vector2 GetPosition();
        public void SetPosition(Vector2 position);
        public void HandleCollision(ICollideable entity, Dictionary<CollisionDirection, bool> collisionDirection);
    }
}
