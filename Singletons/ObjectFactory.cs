using Mario.Entities.Character;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class GameObjectFactory
    {
        // keep track of the number of items created, so we can assign an ID to each
        public int numberOfItems { get; }
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
                case "Mario":
                    // Assuming Mario implements IHero
                    return new Hero(position, numberOfItems);
                case "Goomba":
                    // Assuming Koopa implements IEnemy
                    return new Goomba(position, numberOfItems);
                case "Koopa":
                    // Assuming Koopa implements IEnemy
                    return new Koopa(position, numberOfItems);
                case "Block":
                    // Assuming Block implements IBlock
                    return new Block(position, numberOfItems);
                case "Item":
                    // Assuming Item implements IItem
                    return new Item(position, numberOfItems);
                // Add cases for other entities as needed
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }
    }
}
