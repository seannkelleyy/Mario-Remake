﻿using Mario.Entities.Blocks;
using Mario.Entities.Character;
using Mario.Entities.Items;
using Mario.Interfaces;
using Mario.Interfaces.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mario.Singletons
{
    public class ObjectFactory
    {
        private static ObjectFactory instance = new ObjectFactory();
        public static ObjectFactory Instance => instance;
        private ObjectFactory() { }

        public IHero CreateHero(string startingPower, int lives, Vector2 position)
        {
            return new Hero(startingPower, lives, position);
        }

        public IEnemy CreateEnemy(string type, Vector2 position)
        {
            type = type.ToLower();
            switch (type)
            {
                case "goomba":
                    return new Goomba(position);
                case "koopa":
                    return new Koopa(position);
                default:
                    throw new KeyNotFoundException($"Entity type {type} not recognized.");
            }
        }

        public IBlock CreateBlock(string type, Vector2 position, bool breakeable, bool collideable, string item)
        {
            type = type.ToLower();
            item = item.ToLower();
            switch (type)
            {
                case "floor":
                    return new FloorBlock(position, breakeable, collideable);
                case "brick":
                    return new BrickBlock(position, breakeable, collideable, item);
                case "mystery":
                    return new MysteryBlock(position, breakeable, collideable, item);
                default:
                    throw new KeyNotFoundException($"Block type {type} not recognized.");
            }
        }

        public IItem CreateItem(string type, Vector2 position)
        {
            type = type.ToLower();
            switch (type)
            {
                case "none":
                    return null;
                case "coin":
                    return new Coin(position);
                case "fireflower":
                    return new FireFlower(position);
                case "star":
                    return new Star(position);
                case "mushroom":
                    return new Mushroom(position, "red");
                case "1up":
                    return new Mushroom(position, "1up");
                default:
                    throw new KeyNotFoundException($"Item type `{type}` not recognized.");
            }
        }
    }
}
