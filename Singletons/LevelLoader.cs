using Mario.Global;
using Mario.Interfaces;
using Mario.Interfaces.Base;
using Mario.Interfaces.Entities;
using Mario.Levels.Level;
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

        private LevelLoader() {}

        public void Initialize(ContentManager content)
        {
            this.content = content;
        }

        public void LoadLevel(string levelName)
        {
            string jsonString = File.ReadAllText(levelName);
            Level level = JsonSerializer.Deserialize<Level>(jsonString)!;
            MediaManager mediaManager = MediaManager.Instance;

            // set background for the level
            mediaManager.SetCurrentBackground(level.level);

            // Set default theme
            mediaManager.SetDefaultTheme(level.song);

            SpriteFactory.Instance.LoadAllTextures(content, level.pathToSpriteJson);

            // Create the hero
            IHero hero = ObjectFactory.Instance.CreateHero(
                level.hero.startingPower,
                level.hero.lives,
                new Vector2(level.hero.startingX * GlobalVariables.blockHeightWidth,
                level.hero.startingY * GlobalVariables.blockHeightWidth));
            GameContentManager.Instance.AddEntity(hero);

            // Create the enemies
            foreach (LevelEnemy enemy in level.enemies)
            {
                IEnemy enemyObject = ObjectFactory.Instance.CreateEnemy(
                    enemy.type,
                    new Vector2(enemy.startingX * GlobalVariables.blockHeightWidth,
                    enemy.startingY * GlobalVariables.blockHeightWidth));
                GameContentManager.Instance.AddEntity(enemyObject);
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
                            new Vector2(x * GlobalVariables.blockHeightWidth, y * GlobalVariables.blockHeightWidth),
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
                    new Vector2(block.x * GlobalVariables.blockHeightWidth, block.y * GlobalVariables.blockHeightWidth),
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
                   new Vector2(pipe.x * GlobalVariables.blockHeightWidth, pipe.startingY * GlobalVariables.blockHeightWidth),
                   pipe.isTransportable));

                for (int y = pipe.startingY+1; y <= pipe.endingY; y++)
                {
                        IBlock pipeObject = ObjectFactory.Instance.CreatePipe(
                            "verticalPipeTile",
                            new Vector2(pipe.x * GlobalVariables.blockHeightWidth, y * GlobalVariables.blockHeightWidth),
                            pipe.isTransportable);
                        GameContentManager.Instance.AddEntity(pipeObject);
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
