using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Entities.Blocks.BlockStates;
using System.Collections.Generic;
using System;

namespace Mario.Entities.Blocks
{
    public class ItemBlock : IBlock
    {
        private BlockState currentState;
        private Vector2 position;
        private Dictionary<string, IItem> items = new Dictionary<string, IItem>
        {
            // NOTE: May need to change these declarations after items have been implemented
            {"fireFlower", new FireFlower() },
            {"coin", new Coin() },
            {"mushroom", new Mushroom() },
            {"1up", new OneUp() },
        };
        private IItem item;

        public ItemBlock(Vector2 position, string itemName, string blockType)
        {
            this.position = position;

            // Set the correct type of item block
            if (blockType.CompareTo("brickBlock") == 0)
            {
                currentState = new BrickBlockNormalState();
            } 
            else if (blockType.CompareTo("goldenBlock") == 0)
            {
                currentState = new GoldenBlockState();
            } 
            else
            {
                // Error passing in block type, do something
                Console.Error.WriteLine("Error creating item block");
            }

            // Set the correct item from possible items
            item = items[itemName];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, position);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        // Gives up its item and turns into a hard block
        public void GetHit()
        {
            // Since items haven't been implemented yet, the idea is to create the item in the same place as the block
            // but have it not be visiable until Mario hits the block to get an item. Then the item just needs to be set to visible and drawn 
            // above the block
            item.MakeVisable(); // NOTE: This is subject to change since items haven't been implmented yet
            currentState = new HardBlockState();
        }
    }
}
