using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Mario.Global;

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

        public static MediaManager Instance => instance;
        public void LoadContent(ContentManager content)
        {
            backgrounds = new Dictionary<GlobalVariables.Levels, Texture2D>
            {
                { GlobalVariables.Levels.level1, (content.Load<Texture2D>("background1-1withoutEnd")) }
            };

            soundEffects = new Dictionary<GlobalVariables.EffectNames, SoundEffectInstance>
            {
                { GlobalVariables.EffectNames.oneUp, (content.Load<SoundEffect>("1up")).CreateInstance() },
                { GlobalVariables.EffectNames.bigJump, (content.Load<SoundEffect>("bigJump")).CreateInstance() },
                { GlobalVariables.EffectNames.breakBlock, (content.Load<SoundEffect>("blockbreak")).CreateInstance() },
                { GlobalVariables.EffectNames.bumpBlock, (content.Load<SoundEffect>("bump")).CreateInstance() },
                { GlobalVariables.EffectNames.coin, (content.Load<SoundEffect>("coin")).CreateInstance() },
                { GlobalVariables.EffectNames.enemyFire, (content.Load<SoundEffect>("enemyFire")).CreateInstance() },
                { GlobalVariables.EffectNames.fireball, (content.Load<SoundEffect>("fireball")).CreateInstance() },
                { GlobalVariables.EffectNames.flag, (content.Load<SoundEffect>("flag")).CreateInstance() },
                { GlobalVariables.EffectNames.itemFromBlock, (content.Load<SoundEffect>("item")).CreateInstance() },
                { GlobalVariables.EffectNames.kick, (content.Load<SoundEffect>("kick")).CreateInstance() },
                { GlobalVariables.EffectNames.pause, (content.Load<SoundEffect>("pause")).CreateInstance() },
                { GlobalVariables.EffectNames.pipe, (content.Load<SoundEffect>("pipe")).CreateInstance() },
                { GlobalVariables.EffectNames.powerup, (content.Load< SoundEffect >("powerUp")).CreateInstance() },
                { GlobalVariables.EffectNames.smallJump, (content.Load<SoundEffect>("smallJump")).CreateInstance() },
                { GlobalVariables.EffectNames.stomp, (content.Load<SoundEffect>("stomp")).CreateInstance() },
                { GlobalVariables.EffectNames.vine, (content.Load<SoundEffect>("Vine")).CreateInstance() }
            };

            themes = new Dictionary<GlobalVariables.SongThemes, Song>
            {
                { GlobalVariables.SongThemes.ground, (content.Load<Song>("01-main-theme-overworld")) }
                //{ SongThemes.underground, (content.Load<Song>("02. Underground Theme")) },
                //{ SongThemes.invincibility, (content.Load<Song>("05. Invincibility Theme")) },
                //{ SongThemes.levelComplete, (content.Load<Song>("06. Level Complete")) },
                //{ SongThemes.lostLife, (content.Load<Song>("08. Lost a Life")) },
                //{ SongThemes.gameOver, (content.Load<Song>("09. Game Over")) }
            };
        }

        public void SetDefaultTheme(string theme)
        {
            GlobalVariables.SongThemes check = (GlobalVariables.SongThemes) Enum.Parse(typeof(GlobalVariables.SongThemes), theme);
            defaultTheme = themes[check];
        }
        public void PlayDefaultTheme()
        {
            MediaPlayer.Play(defaultTheme);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayTheme(GlobalVariables.SongThemes theme, Boolean repeat)
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
            spriteBatch.Draw(backgrounds[currentBackground], new Microsoft.Xna.Framework.Vector2(0, 0), Color.White);
        }
    }
}
