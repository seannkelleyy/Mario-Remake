using Microsoft.Xna.Framework;

namespace Mario.Entities.Hero
{
    public class HeroStatTracker
    {

        // Capitalized because they are static
        private double elapsedTime = 0.0;
        public static int Score { get; set; }
        public static int Coins { get; set; }
        public static int Lives { get; set; }
        public static int Time { get; set; }
        public HeroStatTracker(int time, int lives)
        {
            SetTime(time);
            SetLives(lives);
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= 1)
            {
                elapsedTime -= 1;
                SetTime(GetTime() - 1);
            }
        }
        public void SetScore(int score)
        {
            Score = score;
        }

        public void SetCoins(int coins)
        {
            Coins = coins;
        }

        public void SetLives(int lives)
        {
            Lives = lives;
        }

        public void SetTime(int time)
        {
            Time = time;
        }

        public void AddScore(int points)
        {
            Score += points;
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
        }

        public void AddLives(int lives)
        {
            Lives += lives;
        }

        public void AddTime(int time)
        {
            Time += time;
        }

        public int GetScore()
        {
            return Score;
        }

        public int GetCoins()
        {
            return Coins;
        }

        public int GetLives()
        {
            return Lives;
        }

        public int GetTime()
        {
            return Time;
        }
    }
}
