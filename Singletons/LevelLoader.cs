using Mario.Entities.Hero;
using Mario.Global;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Levels.Level;
using Mario.Levels.LevelItems;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Mario.Singletons
{
    public class LevelLoader
    {
        private static LevelLoader instance = new LevelLoader();
        public static LevelLoader Instance => instance;
        private ContentManager content;

        private LevelLoader() { }

        public void Initialize(ContentManager content)
        {
            this.content = content;
        }

        public void LoadLevel(string levelName)
        {
            string jsonString = File.ReadAllText(levelName);
            Level level = JsonSerializer.Deserialize<Level>(jsonString)!;

            GlobalVariables.LevelName = level.level;
            // set background for the level
            MediaManager.Instance.SetCurrentBackground(level.level);

            // Set default theme
            MediaManager.Instance.SetDefaultTheme(level.song);

            GameSettings.LevelEnd = level.width - 5;

            SpriteFactory.Instance.LoadAllTextures(content, level.pathToSpriteJson);

            // Create the hero
            IHero hero = ObjectFactory.Instance.CreateHero(
                level.hero.startingPower,
                new Vector2(level.hero.startingX * GlobalVariables.BlockHeightWidth,
                level.hero.startingY * GlobalVariables.BlockHeightWidth),
                new HeroStatTracker(level.timeLimit, level.hero.lives));
            GameContentManager.Instance.AddEntity(hero);

            // Create the enemies
            foreach (LevelEnemy enemy in level.enemies)
            {
                IEnemy enemyObject = ObjectFactory.Instance.CreateEnemy(
                    enemy.type,
                    new Vector2(enemy.startingX * GlobalVariables.BlockHeightWidth,
                    enemy.startingY * GlobalVariables.BlockHeightWidth),
                    enemy.isRight, enemy.ai);
                GameContentManager.Instance.AddEntity(enemyObject);
            }

            //Creates the Items
            foreach (LevelItem item in level.items)
            {
                IItem itemObject = ObjectFactory.Instance.CreateItem(
                    item.type,
                    new Vector2(item.x * GlobalVariables.BlockHeightWidth,
                    item.y * GlobalVariables.BlockHeightWidth));
                itemObject.MakeVisible();
                GameContentManager.Instance.AddEntity(itemObject);
            }
            //Creates sections of Items
            foreach (LevelItemSection itemSection in level.itemSections)
            {
                for (int x = itemSection.startingX; x <= itemSection.endingX; x++)
                {
                    for (int y = itemSection.startingY; y <= itemSection.endingY; y++)
                    {
                        IItem itemObject = ObjectFactory.Instance.CreateItem(
                    itemSection.type,
                    new Vector2(x * GlobalVariables.BlockHeightWidth,
                    y * GlobalVariables.BlockHeightWidth));
                        itemObject.MakeVisible();
                        GameContentManager.Instance.AddEntity(itemObject);
                    }
                }
            }

            // Create the block sections
            foreach (LevelBlockSection blockSection in level.blockSections)
            {
                for (int x = blockSection.startingX; x <= blockSection.endingX; x++)
                {
                    for (int y = blockSection.startingY; y <= blockSection.endingY; y++)
                    {
                        IBlock block = ObjectFactory.Instance.CreateBlock(
                            blockSection.type,
                            new Vector2(x * GlobalVariables.BlockHeightWidth, y * GlobalVariables.BlockHeightWidth),
                            blockSection.breakable,
                            blockSection.collidable,
                            blockSection.item);
                        GameContentManager.Instance.AddEntity(block);
                    }
                }
            }

            // Create the individual blocks
            foreach (LevelBlock block in level.blocks)
            {
                IBlock blockObject = ObjectFactory.Instance.CreateBlock(
                    block.type,
                    new Vector2(block.x * GlobalVariables.BlockHeightWidth, block.y * GlobalVariables.BlockHeightWidth),
                    block.breakable,
                    block.collidable,
                    block.item);
                GameContentManager.Instance.AddEntity(blockObject);
            }

            // Create pipes
            foreach (LevelPipe pipe in level.pipes)
            {
                GameContentManager.Instance.AddEntity(ObjectFactory.Instance.CreatePipe(
                   pipe.type,
                   new Vector2(pipe.x * GlobalVariables.BlockHeightWidth, pipe.startingY * GlobalVariables.BlockHeightWidth),
                   new Vector2(pipe.transportDestinationX * GlobalVariables.BlockHeightWidth, pipe.transportDestinationY * GlobalVariables.BlockHeightWidth),
                   pipe.collidable,
                   pipe.transportable));
                if (pipe.type.Equals("pipeTubeVertical"))
                {
                    for (int y = pipe.startingY + 2; y <= pipe.endingY; y++)
                    {
                        IPipe pipeObject = ObjectFactory.Instance.CreatePipe(
                            "pipeTile",
                            new Vector2(pipe.x * GlobalVariables.BlockHeightWidth, y * GlobalVariables.BlockHeightWidth),
                            new Vector2(0, 0),
                            pipe.collidable,
                            pipe.transportable);
                        GameContentManager.Instance.AddEntity(pipeObject);
                    }
                }
                else
                {
                    for (int y = pipe.startingY - 1; y >= pipe.endingY; y--)
                    {
                        IPipe pipeObject = ObjectFactory.Instance.CreatePipe(
                            "pipeTile",
                            new Vector2((pipe.x + 2) * GlobalVariables.BlockHeightWidth, y * GlobalVariables.BlockHeightWidth),
                            new Vector2(0, 0),
                            pipe.collidable,
                            pipe.transportable);
                        GameContentManager.Instance.AddEntity(pipeObject);
                    }
                }
            }
        }

        // Removes all entities from the GCM to prepare for reloading the level
        public void UnloadLevel()
        {
            List<IEntityBase> allEntities = GameContentManager.Instance.GetEntities();
            foreach (IEntityBase entity in allEntities)
            {
                GameContentManager.Instance.RemoveEntity(entity);
            }
        }

        // Changes the number of lives Mario will start with in the level-loading JSON file 
        public void ChangeMarioLives(string levelName, int lives)
        {
            string jsonString = File.ReadAllText(levelName);

            // Change the number of lives in the JSON string
            var jsonLives = JsonNode.Parse(jsonString);
            jsonLives["hero"]["lives"] = lives;

            // Save the new number of lives to the JSON file
            jsonString = jsonLives.ToString();
            File.WriteAllText(levelName, jsonString);
        }
    }
}
