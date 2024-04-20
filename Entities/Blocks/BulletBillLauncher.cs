using Mario.Entities.Blocks.BlockStates;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using static Mario.Global.GlobalVariables;
using System;
using System.Collections.Generic;
using Mario.Interfaces.Entities;

namespace Mario.Entities.Blocks
{
    public class BulletBillLauncher : AbstractBlock
    {
        private double shootTimer = 0;
        private double maxNoShootTime = EntitySettings.BulletBillSpawnTime;
        private IEnemy bulletBill;

        public BulletBillLauncher(Vector2 position, bool breakable, bool collidable)
        {
            this.position = position;
            isCollideable = collidable;
            isBreakable = breakable;
            canBeCombined = true;
            currentState = new BulletBillLauncherState();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var direction in Enum.GetValues(typeof(CollisionDirection)))
            {
                SetCollisionState((CollisionDirection)direction, false);
            }
            currentState.Update(gameTime);

            // Check to see if a new bullet bill needs to be launched
            if (shootTimer > maxNoShootTime)
            {
                bulletBill = ObjectFactory.Instance.CreateEnemy("bulletBill", position, false, new List<string>());
                GameContentManager.Instance.AddEntity(bulletBill);
                shootTimer = 0;
            } else
            {
                shootTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public override void GetHit()
        {
            if (isBreakable) GameContentManager.Instance.RemoveEntity(this);
        }
    }
}
