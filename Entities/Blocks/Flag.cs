﻿using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class Flag : AbstractBlock
    {
        public Flag(Vector2 position, bool breakable, bool collidable, bool isUnderground = false)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            canBeCombined = true;
            currentState = new FlagState();
        }

        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
