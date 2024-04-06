using Mario.Global;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System;
using static Mario.Global.GlobalVariables;

namespace Mario.Entities.Blocks
{
    public abstract class AbstractPipe : AbstractCollideable, IPipe
    {
        public GlobalVariables.PipeType type;
        public bool isCollidable {  get; set; }
        public abstract void Transport(IHero mario);

        public override void Update(GameTime gameTime)
        {
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);
        }

        public PipeType GetPipeType()
        {
            return type;
        }
    }
}
