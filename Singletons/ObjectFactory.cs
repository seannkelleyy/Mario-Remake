using Mario.Entities.Blocks;
using Mario.Entities.Character;
using Mario.Entities.Hero;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Mario.Entities.Pipes;
using System;

namespace Mario.Singletons
{
    public class ObjectFactory
    {
        private static ObjectFactory instance = new ObjectFactory();
        public static ObjectFactory Instance => instance;
        private ObjectFactory() { }

        public IHero CreateHero(string startingPower, Vector2 position, HeroStatTracker stats)
        {
            return new Hero(startingPower, position, stats);
        }

        public IEnemy CreateEnemy(string type, Vector2 position)
        {
            switch (type)
            {
                case "goomba":
                    return new Goomba(position);
                case "koopa":
                    return new Koopa(position);
                default:
                    return new Koopa(position);

                    //throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }

        public IBlock CreateBlock(string type, Vector2 position, bool breakeable, bool collideable, string item)
        {
            switch (type)
            {
                case "floor":
                    return new FloorBlock(position, breakeable, collideable);
                case "floorUnderground":
                    return new FloorBlock(position, breakeable, collideable, true);
                case "brick":
                    return new BrickBlock(position, breakeable, collideable, item);
                case "brickUnderground":
                    return new BrickBlock(position, breakeable, collideable, item, true);
                case "mystery":
                    return new MysteryBlock(position, collideable, item);
                default:
                    return new MysteryBlock(position, collideable, item);

                    //throw new KeyNotFoundException($"Block type {type} not recognized.");
            }
        }

        public IItem CreateItem(string type, Vector2 position)
        {
            switch (type)
            {
                case "none":
                    return null;
                case "coin":
                    return new Coin(position);
                case "coinUnderground":
                    return new Coin(position, true);
                case "fireflower":
                    return new FireFlower(position);
                case "star":
                    return new Star(position);
                case "redMushroom":
                    return new Mushroom(position, "red");
                case "oneUp":
                    return new Mushroom(position, "oneUp");
                default:
                    return new Mushroom(position, "oneUp");

                    //throw new KeyNotFoundException($"Item type `{type}` not recognized.");
            }
        }

        public IPipe CreatePipe(string type, Vector2 position, Vector2 transportPosition, bool isCollidable, bool isTransportable)
        {
            switch (type)
            {
                case "pipeTubeVertical":
                    return new PipeTubeVertical(position, transportPosition, isCollidable, isTransportable);
                case "pipeTubeUpsideDown":
                    return new PipeTubeVertical(position, transportPosition, isCollidable, isTransportable, true);
                case "pipeTubeHorizontal":
                    return new PipeTubeHorizontal(position, transportPosition, isCollidable, isTransportable);
                case "pipeTile":
                    return new PipeTile(position, isCollidable);
                default:
                    return new PipeTile(position, isCollidable);

                    //throw new KeyNotFoundException($"Pipe type '{type}' not recognized.");
            }
        }
    }
}
