using Mario.Entities.Blocks.BlockStates;
using Mario.Interfaces;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using System;

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
                // Error passing in block type, do something
                Console.Error.WriteLine("Error creating item block");
            }

            // Give the block an item to hold
            GameObjectFactory gameObjectFactory = GameObjectFactory.Instance;
            // TODO: This instantiation will be changed once items are implemented and can be constructed properly
            item = (IItem)gameObjectFactory.CreateEntity(itemName, position);
        }

        // Gives up its item and turns into a hard block
        public override void GetHit()
        {
            // Since items haven't been implemented yet, the idea is to create the item in the same place as the block
            // but have it not be visiable until Mario hits the block to get an item. Then the item just needs to be set to visible and drawn 
            // above the block
            // item.MakeVisable(); // NOTE: This is subject to change since items haven't been implmented yet
            currentState = new HardBlockState();
        }
    }
}
