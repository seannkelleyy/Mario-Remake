using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class GoldenBlock : AbstractBlock
    {
        private IItem item;

        public GoldenBlock(Vector2 position, bool breakable, bool collidable, string itemName)
        {
            this.position = position;
            isCollidable = collidable;
            isBreakable = breakable;
            currentState = new GoldenBlockState();

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
                    // Error passing in item type
                    Logger.Instance.LogError($"Item type `{itemName}` not recognized.");
                    break;
            }
        }

        // Gives up its item and turns into a hard block
        public override void GetHit()
        {
            item.MakeVisable();
            currentState = new HardBlockState();
        }
    }
}
