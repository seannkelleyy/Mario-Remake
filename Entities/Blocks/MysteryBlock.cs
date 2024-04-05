using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class MysteryBlock : AbstractBlock
    {
        private IItem item;
        private MediaManager mediaManager = MediaManager.Instance;

        public MysteryBlock(Vector2 position, bool breakable, bool collidable, string itemName)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            currentState = new GoldenBlockState();
            canBeCombined = false;

            // Give the block an item to hold
            switch (itemName)
            {
                case "none":
                    item = null;
                    break;
                case "mushroom":
                    item = ObjectFactory.Instance.CreateItem("mushroom", position);
                    break;
                case "fireflower":
                    item = ObjectFactory.Instance.CreateItem("fireflower", position);
                    break;
                case "coin":
                    item = ObjectFactory.Instance.CreateItem("coin", position);
                    break;
                case "1up":
                    item = ObjectFactory.Instance.CreateItem("1up", position);
                    break;
                case "star":
                    item = ObjectFactory.Instance.CreateItem("star", position);
                    break;
                default:
                    Logger.Instance.LogError($"Item type `{itemName}` not recognized.");
                    break;
            }
        }

        // Gives up its item and turns into a hard block
        public override void GetHit()
        {
            if (currentState is not HardBlockState)
            {
                mediaManager.PlayEffect(MediaManager.EffectNames.bumpBlock);
                GameContentManager.Instance.AddEntity(item);
                if (item != null)
                {
                    item.MakeVisible();
                }
                currentState = new HardBlockState();
            }
            if (isBreakable)
            {
                mediaManager.PlayEffect(MediaManager.EffectNames.breakBlock);
                GameContentManager.Instance.RemoveEntity(this);
            }
        }
    }
}
