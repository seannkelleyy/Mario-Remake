using Mario.Entities.Blocks;
using Mario.Entities.Character;
using Mario.Entities.Hero;
using Mario.Entities.Items;
using Mario.Entities.Pipes;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Mario.Entities;

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

        public IEnemy CreateEnemy(string type, Vector2 position, bool isRight)
        {
            switch (type)
            {
                case "goomba":
                    return new Goomba(position, isRight);
                case "koopa":
                    return new Koopa(position, isRight);
                case "bulletBill":
                    return new BulletBill(position);
                case "firebro":
                    return new FireBro(position, isRight);
                case "piranha":
                    return new PiranhaPlant(position);
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }

        public IBlock CreateBlock(string type, Vector2 position, bool breakable, bool collideable, string item)
        {
            switch (type)
            {
                case "floor":
                    return new FloorBlock(position, breakable, collideable);
                case "floorUnderground":
                    return new FloorBlock(position, breakable, collideable, true);
                case "brick":
                    return new BrickBlock(position, breakable, collideable, item);
                case "brickUnderground":
                    return new BrickBlock(position, breakable, collideable, item, true);
                case "mystery":
                    return new MysteryBlock(position, collideable, item);
                case "bulletBillLauncher":
                    return new BulletBillLauncher(position, breakable, collideable);
                case "stone":
                    return new StoneBlock(position, breakable, collideable);
                case "flag":
                    return new Flag(position, breakable, collideable);
                case "deathBlock":
                    return new DeathBlock(position, breakable, collideable);
                default:
                    throw new KeyNotFoundException($"Block type {type} not recognized.");
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
                case "pistol":
                    return new Pistol(position);
                case "shotgun":
                    return new Shotgun(position);
                case "rocketLauncher":
                    return new RocketLauncher(position);
                default:
                    throw new KeyNotFoundException($"Item type `{type}` not recognized.");
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
                    throw new KeyNotFoundException($"Pipe type '{type}' not recognized.");
            }
        }
    }
}
