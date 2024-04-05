﻿using Mario.Entities.Items.ItemStates;
using Mario.Global;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Items
{
    public class FireFlower : AbstractItem
    {
        public FireFlower(Vector2 position)
        {
            this.position = position;
            currentState = new FireFlowerState();
        }

        public override void MakeVisible()
        {
            position.Y -= GlobalVariables.blockHeightWidth;
            isVisible = true;
            isCollidable = true;
        }

        public override void ChangeDirection()
        {
            Logger.Instance.LogInformation("ChangeDirection not implemented in FireFlower");
        }
        public override Vector2 GetVelocity()
        {
            return Vector2.Zero;
        }
    }
}
