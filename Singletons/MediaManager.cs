using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace Mario.Singletons
{
    internal class MediaManager
    {
        private static MediaManager instance = new();
        private Dictionary<SongThemes, Song> themes;
        private Dictionary<EffectNames, SoundEffectInstance> soundEffects;
        private Dictionary<Levels, Texture2D> backgrounds;
        private Song defaultTheme;
        private Levels currentBackground;
        
        public enum Levels
        {
            level1 = 1,
            level2 = 2,
            level3 = 3,
            level4 = 4,
            level5 = 5,
            level6 = 6,
            level7 = 7,
            level8 = 8
        }
        public enum EffectNames
        {
            oneUp,
            bigJump,
            breakBlock,
            bumpBlock,
            coin,
            enemyFire,
            fireball,
            flag,
            itemFromBlock,
            kick,
            smallJump,
            stomp,
            pause,
            powerup,
            vine, // Most likely will be unused.
            pipe
        }
        public enum SongThemes
        {
            ground,
            underground,
            invincibility,
            levelComplete,
            lostLife,
            gameOver
        };


        public static MediaManager Instance => instance;
        public void LoadContent(ContentManager content)
        {
            backgrounds = new Dictionary<Levels, Texture2D>
            {
                { Levels.level1, (content.Load<Texture2D>("background1-1withoutEnd")) }
            };

            soundEffects = new Dictionary<EffectNames, SoundEffectInstance>
            {
                { EffectNames.oneUp, (content.Load<SoundEffect>("1up")).CreateInstance() },
                { EffectNames.bigJump, (content.Load<SoundEffect>("bigJump")).CreateInstance() },
                { EffectNames.breakBlock, (content.Load<SoundEffect>("blockbreak")).CreateInstance() },
                { EffectNames.bumpBlock, (content.Load<SoundEffect>("bump")).CreateInstance() },
                { EffectNames.coin, (content.Load<SoundEffect>("coin")).CreateInstance() },
                { EffectNames.enemyFire, (content.Load<SoundEffect>("enemyFire")).CreateInstance() },
                { EffectNames.fireball, (content.Load<SoundEffect>("fireball")).CreateInstance() },
                { EffectNames.flag, (content.Load<SoundEffect>("flag")).CreateInstance() },
                { EffectNames.itemFromBlock, (content.Load<SoundEffect>("item")).CreateInstance() },
                { EffectNames.kick, (content.Load<SoundEffect>("kick")).CreateInstance() },
                { EffectNames.pause, (content.Load<SoundEffect>("pause")).CreateInstance() },
                { EffectNames.pipe, (content.Load<SoundEffect>("pipe")).CreateInstance() },
                { EffectNames.powerup, (content.Load< SoundEffect >("powerUp")).CreateInstance() },
                { EffectNames.smallJump, (content.Load<SoundEffect>("smallJump")).CreateInstance() },
                { EffectNames.stomp, (content.Load<SoundEffect>("stomp")).CreateInstance() },
                { EffectNames.vine, (content.Load<SoundEffect>("Vine")).CreateInstance() }
            };

            themes = new Dictionary<SongThemes, Song>
            {
                { SongThemes.ground, (content.Load<Song>("01-main-theme-overworld")) }
                //{ SongThemes.underground, (content.Load<Song>("02. Underground Theme")) },
                //{ SongThemes.invincibility, (content.Load<Song>("05. Invincibility Theme")) },
                //{ SongThemes.levelComplete, (content.Load<Song>("06. Level Complete")) },
                //{ SongThemes.lostLife, (content.Load<Song>("08. Lost a Life")) },
                //{ SongThemes.gameOver, (content.Load<Song>("09. Game Over")) }
            };
        }

        public void SetDefaultTheme(string theme)
        {
            SongThemes check = (SongThemes) Enum.Parse(typeof(SongThemes), theme);
            defaultTheme = themes[check];
        }
        public void PlayDefaultTheme()
        {
            MediaPlayer.Play(defaultTheme);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayTheme(SongThemes theme, Boolean repeat)
        {
            MediaPlayer.Play(themes[theme]);
            MediaPlayer.IsRepeating = repeat;
        }

        public void PlayEffect(EffectNames name)
        {
            soundEffects[name].Play();
        }

        public void SetCurrentBackground(string level)
        {
            currentBackground = (Levels)Enum.Parse(typeof(Levels), level);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrounds[currentBackground], new Microsoft.Xna.Framework.Vector2(0, 0), Color.White);
        }
    }
}
