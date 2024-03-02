using Mario.Interfaces.Entities;
using Mario.Entities.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Mario.Entities.Character;
using Mario.Entities.Blocks;
using Mario.Interfaces;

namespace Mario.Singletons
{
    public class GameObjectFactory
    {
        private static GameObjectFactory instance = new GameObjectFactory();
        //private Dictionary<string, Vector2> entityPosition;

        // Singleton instance property
        public static GameObjectFactory Instance => instance;

        // Private constructor to prevent instantiation
        private GameObjectFactory() { }

        // Factory method to create game entities
        public IEntityBase CreateEntity(string type, Vector2 position)
        {
            switch (type)
            {
                case "Mario":
                    // Assuming Mario implements IHero
                    return new Hero(position);
                case "Goomba":
                    // Assuming Koopa implements IEnemy
                    return new Goomba(position);
                case "Koopa":
                    // Assuming Koopa implements IEnemy
                    return new Koopa(position);
                
                case "FloorBlock": // Floor block is an IEntityBase not IBlock
                    return new FloorBlock(position);
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

        // Returns a new coin
        public IItem CreateCoin(Vector2 position)
        {
            return new Coin(position);
        }

        // Returns a new fire flower
        public IItem CreateFireFlower(Vector2 position)
        {
            return new FireFlower(position);
        }

        // Returns a new star
        public IItem CreateStar(Vector2 position)
        {
            return new Star(position);
        }

        // Returns a new mushrrom (red mushroom or 1up)
        public IItem CreateMushroom(Vector2 position, string mushroomType)
        {
            return new Mushroom(position, mushroomType);
        }
    }
}
