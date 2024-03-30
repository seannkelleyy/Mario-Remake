using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
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
        private static MediaManager instance;
        private Dictionary<SongThemes, Song> themes;
        private Dictionary<EffectNames, SoundEffect> soundEffects;
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
            soundEffects = new Dictionary<EffectNames, SoundEffect>
            {
                { EffectNames.oneUp, (content.Load<SoundEffect>("1up.mp3")) },
                { EffectNames.bigJump, (content.Load<SoundEffect>("Big Jump.mp3")) },
                { EffectNames.bowserDeath, (content.Load<SoundEffect>("Bowser Die.mp3")) },
                { EffectNames.breakBlock, (content.Load<SoundEffect>("Break.mp3")) },
                { EffectNames.bumpBlock, (content.Load<SoundEffect>("Bump.mp3")) },
                { EffectNames.enemyFire, (content.Load<SoundEffect>("Enemy Fire.mp3")) },
                { EffectNames.fireball, (content.Load<SoundEffect>("Fire Ball.mp3")) },
                { EffectNames.flag, (content.Load<SoundEffect>("Flagpole.mp3")) },
                { EffectNames.itemFromBlock, (content.Load<SoundEffect>("Item.mp3")) },
                { EffectNames.smallJump, (content.Load<SoundEffect>("Jump.mp3")) },
                { EffectNames.pause, (content.Load<SoundEffect>("Pause.mp3")) },
                { EffectNames.powerup, (content.Load<SoundEffect>("Powerup.mp3")) },
                { EffectNames.skid, (content.Load<SoundEffect>("Skid.mp3")) },
                { EffectNames.squish, (content.Load<SoundEffect>("Squish.mp3")) },
                { EffectNames.thwomp, (content.Load<SoundEffect>("Thwomp.mp3")) },
                { EffectNames.vine, (content.Load<SoundEffect>("Vine.mp3")) },
                { EffectNames.pipe, (content.Load<SoundEffect>("Warp.mp3")) },
                { EffectNames.beep, (content.Load<SoundEffect>("Beep.mp3")) }
            };
            themes = new Dictionary<SongThemes, Song>
            {
                { SongThemes.ground, (content.Load<Song>("01. Ground Theme.mp3")) },
                { SongThemes.underground, (content.Load<Song>("02. Underground Theme.mp3")) },
                { SongThemes.invincibility, (content.Load<Song>("05. Invincibility Theme.mp3")) },
                { SongThemes.levelComplete, (content.Load<Song>("06. Level Complete.mp3")) },
                { SongThemes.lostLife, (content.Load<Song>("08. Lost a Life.mp3")) },
                { SongThemes.gameOver, (content.Load<Song>("09. Game Over.mp3")) }
            };
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
    }
}
