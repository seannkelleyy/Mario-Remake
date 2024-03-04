using Mario.Entities.Blocks;
using Mario.Entities.Character;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class GameObjectFactory
    {
        // keep track of the number of items created, so we can assign an ID to each
        private static GameObjectFactory instance = new GameObjectFactory();

        // Singleton instance property
        public static GameObjectFactory Instance => instance;

        // Private constructor to prevent instantiation
        private GameObjectFactory() { }

        // Factory method to create game entities
        public IEntityBase CreateEntity(string type, Vector2 position)
        {
            switch (type)
            {
                case "mario":
                    // Assuming Mario implements IHero
                    return new Hero(position);
                case "goomba":
                    // Assuming Koopa implements IEnemy
                    return new Goomba(position);
                case "koopa":
                    // Assuming Koopa implements IEnemy
                    return new Koopa(position);

                case "floorBlock": // Floor block is an IEntityBase not IBlock
                    return new FloorBlock(position);
                case "item":
                // Assuming Item implements IItem
                // return new Item(position);
                // Add cases for other entities as needed
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }

        // Returns a new empty brick block
        public IBlock CreateItemBlock(Vector2 position)
        {
            return new EmptyBrickBlock(position);
        }

        // Returns a new item block
        public IBlock CreateItemBlock(Vector2 position, string itemName, string itemBlockType)
        {
            return new ItemBlock(position, itemName, itemBlockType);
        }

        // Returns a new coin block
        public IBlock CreateCoinBlock(Vector2 position, int coinAmount)
        {
            return new CoinBlock(position, coinAmount);
        }
    }
}
