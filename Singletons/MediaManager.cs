using Mario.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Mario.Singletons
{
    internal class MediaManager
    {
        private static MediaManager instance = new();
        private Dictionary<GlobalVariables.SongThemes, Song> themes;
        private Dictionary<GlobalVariables.EffectNames, SoundEffectInstance> soundEffects;
        private Dictionary<GlobalVariables.Levels, Texture2D> backgrounds;
        private Song defaultTheme;
        private GlobalVariables.Levels currentBackground;

        // Uses Singleton pattern.
        public static MediaManager Instance => instance;
        public void LoadContent(ContentManager content)
        {
            // Initialize dictionary containing level backgrounds.
            backgrounds = new Dictionary<GlobalVariables.Levels, Texture2D>
            {
                { GlobalVariables.Levels.level1, content.Load<Texture2D>("background1-1withoutEnd") }
            };

            // Initialize dictionary containing all Sfx.
            soundEffects = new Dictionary<GlobalVariables.EffectNames, SoundEffectInstance>
            {
                { GlobalVariables.EffectNames.oneUp, content.Load<SoundEffect>("1up").CreateInstance() },
                { GlobalVariables.EffectNames.bigJump, content.Load<SoundEffect>("bigJump").CreateInstance() },
                { GlobalVariables.EffectNames.breakBlock, content.Load<SoundEffect>("blockbreak").CreateInstance() },
                { GlobalVariables.EffectNames.bumpBlock, content.Load<SoundEffect>("bump").CreateInstance() },
                { GlobalVariables.EffectNames.coin, content.Load<SoundEffect>("coin").CreateInstance() },
                { GlobalVariables.EffectNames.enemyFire, content.Load<SoundEffect>("enemyFire").CreateInstance() },
                { GlobalVariables.EffectNames.fireball, content.Load<SoundEffect>("fireball").CreateInstance() },
                { GlobalVariables.EffectNames.flag, content.Load<SoundEffect>("flag").CreateInstance() },
                { GlobalVariables.EffectNames.itemFromBlock, content.Load<SoundEffect>("item").CreateInstance() },
                { GlobalVariables.EffectNames.kick, content.Load<SoundEffect>("kick").CreateInstance() },
                { GlobalVariables.EffectNames.pause, content.Load<SoundEffect>("pause").CreateInstance() },
                { GlobalVariables.EffectNames.pipe, content.Load<SoundEffect>("pipe").CreateInstance() },
                { GlobalVariables.EffectNames.powerup, content.Load< SoundEffect >("powerUp").CreateInstance() },
                { GlobalVariables.EffectNames.smallJump, content.Load<SoundEffect>("smallJump").CreateInstance() },
                { GlobalVariables.EffectNames.stomp, content.Load<SoundEffect>("stomp").CreateInstance() },
                { GlobalVariables.EffectNames.vine, content.Load<SoundEffect>("Vine").CreateInstance() }
            };

            // Initialize dictionary containing all songs.
            themes = new Dictionary<GlobalVariables.SongThemes, Song>
            {
                { GlobalVariables.SongThemes.ground, content.Load<Song>("01-main-theme-overworld") },
                { GlobalVariables.SongThemes.underground, content.Load<Song>("02-underworld") },
                { GlobalVariables.SongThemes.underwater, content.Load<Song>("03-underwater") },
                { GlobalVariables.SongThemes.castle, content.Load<Song>("04-castle") },
                { GlobalVariables.SongThemes.invincibility, content.Load<Song>("05-starman") },
                { GlobalVariables.SongThemes.levelComplete, content.Load<Song>("06-level-complete") },
                { GlobalVariables.SongThemes.castleComplete, content.Load<Song>("07-castle-complete") },
                { GlobalVariables.SongThemes.lostLife, content.Load<Song>("08-you-re-dead") },
                { GlobalVariables.SongThemes.gameOver, content.Load<Song>("09-game-over") },
                { GlobalVariables.SongThemes.ending, content.Load<Song>("12-ending") }
            };
        }

        public void SetDefaultTheme(string theme)
        {
            GlobalVariables.SongThemes check = (GlobalVariables.SongThemes)Enum.Parse(typeof(GlobalVariables.SongThemes), theme);
            defaultTheme = themes[check];
        }
        public void PlayDefaultTheme()
        {
            MediaPlayer.Play(defaultTheme);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayTheme(GlobalVariables.SongThemes theme, bool repeat)
        {
            MediaPlayer.Play(themes[theme]);
            MediaPlayer.IsRepeating = repeat;
        }

        public void PlayEffect(GlobalVariables.EffectNames name)
        {
            soundEffects[name].Play();
        }

        public void SetCurrentBackground(string level)
        {
            currentBackground = (GlobalVariables.Levels)Enum.Parse(typeof(GlobalVariables.Levels), level);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrounds[currentBackground], new Vector2(0, 0), Color.White);
        }
    }
}
