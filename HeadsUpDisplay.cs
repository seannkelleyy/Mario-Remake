using System;

public class Statistics
{
    public int coins;
    public int lives;
    public int score;
    public int time;
    public string level;
    public int LeftEdgeOfScreen;

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

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw("Mario      Coins    Lives    Time    World", new Vector2(LeftEdgeOfScreen + 10, 10), Color.White);
        spriteBatch.Draw(ScoreAsText(score) + "   " + coins + "       " + lives + "        " + time + "     1-1", new Vector2(LeftEdgeOfScreen + 10, 25), Color.White);)
    }

    pubic void Update(GameTime gameTime)
    {
        LeftEdgeOfScreen = PlayerCamera.GetLeftEdge();
        time = gameTime.ElapsedGameTime;
    }
}
