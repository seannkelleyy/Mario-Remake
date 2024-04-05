using Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Blocks
{
    public abstract class AbstractBlock : AbstractCollideable, IBlock
    {
        public bool isCollidable { get; set; }
        public bool isBreakable { get; set; }
        public bool canBeCombined { get; set; }

        public abstract void GetHit();

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
