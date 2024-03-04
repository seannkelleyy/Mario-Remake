using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mario.Entities.Blocks
{
    public class ItemBlock : AbstractBlock
    {
        public bool isCollidable { get; } = true;
        public bool isBreakable { get; } = false;
        private IItem item;

        public ItemBlock(Vector2 position, string itemName, string itemBlockType)
        {
            this.position = position;

            // Set the correct sprite of this item block
            if (itemBlockType.CompareTo("brickBlock") == 0)
            {
                currentState = new BrickBlockNormalState();
            }
            else if (itemBlockType.CompareTo("goldenBlock") == 0)
            {
                currentState = new GoldenBlockState();
            }
            else
            {
                // Error passing in item block type
                throw new KeyNotFoundException($"ItemBlock type {itemBlockType} not recognized.");
            }

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
                    throw new KeyNotFoundException($"Item type {itemName} not recognized.");
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
