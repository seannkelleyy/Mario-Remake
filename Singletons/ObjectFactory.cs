using Mario.Entities.Blocks;
using Mario.Entities.Character;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Base;
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
                // Add cases for other entities as needed
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }

        public IBlock CreateBlock(string type, Vector2 position, bool breakeable, bool collideable, string item)
        {
            switch (type)
            {
                case "floor":
                    return new FloorBlock(position, breakeable, collideable, item);
                case "brick":
                    return new BrickBlock(position, breakeable, collideable);
                case "question":
                    return new QuestionBlock(position, breakeable, collideable, item);
                case "pipe":
                    return new Pipe(position, breakeable, collideable);
                case "flag":
                    return new Flag(position, breakeable, collideable);
                default:
                    throw new KeyNotFoundException($"Block type {type} not recognized.");
            }
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
