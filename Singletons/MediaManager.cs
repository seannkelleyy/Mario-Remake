using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Mario.Singletons
{
    internal class MediaManager
    {
        private static MediaManager instance;
        private Dictionary<SongThemes, Song> themes;
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

        public void Play(SongThemes theme, Boolean repeat)
        {
            MediaPlayer.Play(themes[theme]);
            MediaPlayer.IsRepeating = repeat;
        }
    }
}
