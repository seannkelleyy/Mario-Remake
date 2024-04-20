using Mario.Entities.Blocks.BlockStates;
using Mario.Global;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class MysteryBlock : AbstractBlock
    {
        private IItem item;

        public MysteryBlock(Vector2 position, bool collidable, string itemName)
        {
            this.position = position;
            isCollideable = collidable;
            currentState = new GoldenBlockState();
            canBeCombined = false;

            // Give the block an item to hold
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
                case "pistol":
                    item = ObjectFactory.Instance.CreateItem("pistol", position);
                    break;
                case "shotgun":
                    item = ObjectFactory.Instance.CreateItem("shotgun", position);
                    break;
                case "rocketLauncher":
                    item = ObjectFactory.Instance.CreateItem("rocketLauncher", position);
                    break;
                default:
                    Logger.Instance.LogError($"Item type `{itemName}` not recognized.");
                    break;
            }
        }

        // Gives up its item and turns into a hard block
        public override void GetHit()
        {
            if (currentState is not EmptyBlockState)
            {
                MediaManager.Instance.PlayEffect(GlobalVariables.EffectNames.bumpBlock);
                GameContentManager.Instance.AddEntity(item);
                if (item != null)
                {
                    item.MakeVisible();
                }
                currentState = new EmptyBlockState();
            }
        }
    }
}
