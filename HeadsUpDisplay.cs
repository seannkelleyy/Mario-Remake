using System;

public class Statistics
{
    public int coins { get; set; }
    public int lives { get; set; }
    public int score { get; set; }
    public int time { get; set; }
    public string level { get; set; }
    public int LeftEdgeOfScreen { get; set; }

    public Statistics()
    {
        coins = 0;
        lives = 3;
        score = 0;
        time = 0;
        level = "1-1";
        LeftEdgeOfScreen = 0;
    }


    public void CoinCollected()
    {
        coins++;
    }
    public void AddScore(int points)
    {
        score += points;
    }
    public void AddLife()
    {
        lives++;
    }
    public void LoseLife()
    {
        lives--;
    }
    public void EnemyKilled()
    {
        score += 100;
    }
    public void ScoreAsText(int score)
    {
        int gameScore = score;
        string scoreText = "";
        while (gameScore > 0)
        {
            scoreText = (gameScore % 10) + scoreText;
            gameScore /= 10;
        }
        return scoreText;
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
        spriteBatch.Draw(font, "Mario      Coins    Lives    Time    World", new Vector2(10, 10), Color.White);
        spriteBatch.Draw(font, ScoreAsText(score) + "   " + coins + "       " + lives + "        " + time + "     1-1", new Vector2(10, 25), Color.White);)
    }
}
