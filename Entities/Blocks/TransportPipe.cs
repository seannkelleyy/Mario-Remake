﻿using Mario.Entities.Blocks.BlockStates;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class TransportPipe : AbstractBlock
    {
        private bool isTransportable;
        public TransportPipe(Vector2 position, bool isTransportable)
        {
            this.position = position;
            currentState = new PipeTubeState();
            isCollidable = true;
            isBreakable = false;
            this.isTransportable = isTransportable;
        }
        public override void GetHit()
        {
            //Pipes aren't breakable could be utilized for transportation
        }
    }
}
