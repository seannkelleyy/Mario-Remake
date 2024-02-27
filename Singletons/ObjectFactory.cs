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
        private Dictionary<string, Vector2> entityPosition;
        private ISprite[] items;

        // Singleton instance property
        public static GameObjectFactory Instance => instance;

        // Private constructor to prevent instantiation
        private GameObjectFactory() { }

        // Factory method to create game entities
        public IEntityBase CreateEntity(string type)
        {
            switch (type)
            {
                case "Mario":
                    // Assuming Mario implements IHero
                    return new Hero(entityPosition[type]);
                case "Goomba":
                    // Assuming Koopa implements IEnemy
                    return new Goomba(entityPosition[type]);
                case "Koopa":
                    // Assuming Koopa implements IEnemy
                    return new Koopa(entityPosition[type]);
                case "Block":
                    // Assuming Block implements IBlock
                    return new Block(entityPosition[type]);
                case "Item":
                    // Assuming Item implements IItem
                    return new Item(items, entityPosition[type]);
                // Add cases for other entities as needed
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }
    }
}
