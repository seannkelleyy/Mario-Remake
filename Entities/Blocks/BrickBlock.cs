using Mario.Entities.Blocks.BlockStates;
using Mario.Global;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        private IItem item;
        public BrickBlock(Vector2 position, bool breakable, bool collidable, string itemName, bool isUnderground = false)
        {
            this.position = position;
            isCollideable = collidable;
            isBreakable = breakable;
            canBeCombined = false;

            if (isUnderground) currentState = new BrickBlockUndergroundNormalState();
            else currentState = new BrickBlockNormalState();

            switch (itemName)
            {
                case "none":
                    item = null;
                    break;
                case "redMushroom":
                    item = ObjectFactory.Instance.CreateItem("redMushroom", position);
                    break;
                case "fireflower":
                    item = ObjectFactory.Instance.CreateItem("fireflower", position);
                    break;
                case "coin":
                    item = ObjectFactory.Instance.CreateItem("coin", position);
                    break;
                case "coinUnderground":
                    item = ObjectFactory.Instance.CreateItem("coinUnderground", position);
                    break;
                case "oneUp":
                    item = ObjectFactory.Instance.CreateItem("oneUp", position);
                    break;
                case "star":
                    item = ObjectFactory.Instance.CreateItem("star", position);
                    break;
                default:
                    Logger.Instance.LogError($"Item type `{itemName}` not recognized.");
                    break;
            }
        }

        // Block will be broken
        public override void GetHit()
        {
            if (isBreakable)
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.breakBlock);
                GameContentManager.Instance.RemoveEntity(this);
            }
            else
            {
                if (item != null)
                {
                    item.MakeVisible();
                }
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.bumpBlock);
                currentState = new BrickBlockBrokenState();
                isCollideable = false;
            }
        }
    }
}
