using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;

namespace Mario.Entities.Blocks
{
    public class GoldenBlock : AbstractBlock
    {
        private IItem item;

        public GoldenBlock(Vector2 position, bool breakeable, bool collideable, string itemName)
        {
            this.position = position;
            isCollidable = true;
            isBreakable = false;

            currentState = new GoldenBlockState();

            // Give the block an item to hold
            GameObjectFactory gameObjectFactory = GameObjectFactory.Instance;
            switch (itemName)
            {
                case "mushroom":
                    item = gameObjectFactory.CreateMushroom(position, "redMushroom");
                    break;
                case "fireFlower":
                    item = gameObjectFactory.CreateFireFlower(position);
                    break;
                case "coin":
                    item = gameObjectFactory.CreateCoin(position);
                    break;
                case "1up":
                    item = gameObjectFactory.CreateMushroom(position, "1up");
                    break;
                case "star":
                    item = gameObjectFactory.CreateStar(position);
                    break;
                default:
                    // Error passing in item type
                    Logger.Instance.LogError($"Item type {itemName} not recognized.");
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
