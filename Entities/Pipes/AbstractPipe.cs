using Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.CollisionVariables;

namespace Mario.Entities.Pipes
{
    public abstract class AbstractPipe : AbstractCollideable, IPipe
    {
        public bool isCollidable { get; set; }
        public bool isTransport { get; set; }


        public override void Update(GameTime gameTime)
        {
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);
        }
    }
}