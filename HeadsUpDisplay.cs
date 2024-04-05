using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

public class Statistics
{
    public int coins;
    public int lives;
    public int score;
    public int time;
    public string level;
    public float LeftEdgeOfScreen;

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
    public String ScoreAsText(int score)
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
        spriteBatch.DrawString(font, "Mario      Coins    Lives    Time    World", new Vector2(LeftEdgeOfScreen + 10, 10), Color.White);
        spriteBatch.DrawString(font, ScoreAsText(score) + "   " + coins + "       " + lives + "        " + time + "     1-1", new Vector2(LeftEdgeOfScreen + 10, 25), Color.White);
    }

    public void Update(GameTime gameTime)
    {
        LeftEdgeOfScreen = Mario.PlayerCamera.GetLeftEdge();
        time = (int)gameTime.ElapsedGameTime.TotalSeconds;
    }
}
