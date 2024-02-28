using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Mario.Entities.Character;

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
                case "Block":
                    // Assuming Block implements IBlock
                    return new Block(position);
                case "Item":
                    // Assuming Item implements IItem
                    return new Item(position);
                // Add cases for other entities as needed
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }
    }
}
