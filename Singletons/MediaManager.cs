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

namespace Mario.Singletons
{
    internal class MediaManager
    {
        private static MediaManager instance = new();
        private Dictionary<SongThemes, Song> themes;
        private Dictionary<EffectNames, SoundEffectInstance> soundEffects;
        private Dictionary<Levels, Texture2D> backgrounds;
        public Song previousSong;
        
        public enum Levels
        {
            level1,
            level2,
            level3,
            level4,
            level5,
            level6,
            level7,
            level8
        }
        public enum EffectNames
        {
            oneUp,
            bigJump,
            bowserDeath, // Most likely will be unused.
            breakBlock,
            bumpBlock,
            enemyFire,
            fireball,
            flag,
            itemFromBlock,
            smallJump,
            stomp,
            pause,
            powerup,
            skid, // Unsure of what this effect is for.
            squish, // Unsure of what this effect is for.
            thwomp, // Unsure.
            vine, // Most likely will be unused.
            pipe,
            beep // Mostly unused.
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
                { EffectNames.bigJump, (content.Load < SoundEffect >("Big Jump")).CreateInstance() },
                { EffectNames.bowserDeath, (content.Load < SoundEffect >("Bowser Die")).CreateInstance() },
                { EffectNames.breakBlock, (content.Load < SoundEffect >("Break")).CreateInstance() },
                { EffectNames.bumpBlock, (content.Load < SoundEffect >("Bump")).CreateInstance() },
                { EffectNames.enemyFire, (content.Load < SoundEffect >("Enemy Fire")).CreateInstance() },
                { EffectNames.fireball, (content.Load < SoundEffect >("Fire Ball")).CreateInstance() },
                { EffectNames.flag, (content.Load < SoundEffect >("Flagpole")).CreateInstance() },
                { EffectNames.itemFromBlock, (content.Load < SoundEffect >("Item")).CreateInstance() },
                { EffectNames.smallJump, (content.Load < SoundEffect >("Jump")).CreateInstance() },
                { EffectNames.pause, (content.Load < SoundEffect >("Pause")).CreateInstance() },
                { EffectNames.powerup, (content.Load < SoundEffect >("Powerup")).CreateInstance() },
                { EffectNames.skid, (content.Load < SoundEffect >("Skid")).CreateInstance() },
                { EffectNames.squish, (content.Load < SoundEffect >("Squish")).CreateInstance() },
                { EffectNames.thwomp, (content.Load < SoundEffect >("Thwomp")).CreateInstance() },
                { EffectNames.vine, (content.Load < SoundEffect >("Vine")).CreateInstance() },
                { EffectNames.pipe, (content.Load < SoundEffect >("Warp")).CreateInstance() },
                { EffectNames.beep, (content.Load < SoundEffect >("Beep")).CreateInstance() }
            };

            themes = new Dictionary<SongThemes, Song>
            {
                { SongThemes.ground, (content.Load<Song>("01. Ground Theme")) },
                { SongThemes.underground, (content.Load<Song>("02. Underground Theme")) },
                { SongThemes.invincibility, (content.Load<Song>("05. Invincibility Theme")) },
                { SongThemes.levelComplete, (content.Load<Song>("06. Level Complete")) },
                { SongThemes.lostLife, (content.Load<Song>("08. Lost a Life")) },
                { SongThemes.gameOver, (content.Load<Song>("09. Game Over")) }
            };
        }

        public void PlayTheme(SongThemes theme, Boolean repeat)
        {
            previousSong = MediaPlayer.Queue.ActiveSong;
            MediaPlayer.Play(themes[theme]);
            MediaPlayer.IsRepeating = repeat;
        }

        public void PlayEffect(EffectNames name)
        {
            soundEffects[name].Play();
        }

        public void Draw(SpriteBatch spriteBatch, Levels level)
        {
            spriteBatch.Draw(backgrounds[level], new Vector2(0, 0), Color.White);
        }
    }
}
