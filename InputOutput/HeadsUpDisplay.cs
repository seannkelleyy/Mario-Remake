﻿using Mario.Global;
using Mario.Interfaces.Entities;
using Mario.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

public class HeadsUpDisplay
{
    private IHero player;

    public HeadsUpDisplay()
    {
        player = GameContentManager.Instance.GetHero();
    }

    // This is jsut making it so the HUD is drawn in the center of the screen
    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
        string[] headers = new string[] { "Score", "Coins", "Lives", "Time", "World" };
        string[] values = new string[] { player.GetStats().GetScore().ToString(), player.GetStats().GetCoins().ToString(), player.GetStats().GetLives().ToString(), player.GetStats().GetTime().ToString(), $"1-{GlobalVariables.LevelName}" };

        float totalWidth = 0;
        for (int i = 0; i < headers.Length; i++)
        {
            totalWidth += font.MeasureString(headers[i]).X + GlobalVariables.HUDBuffer;
        }

        float currentX = GlobalVariables.CameraLeftEdge + ((GameSettings.ScreenSize.X - totalWidth) / 2);
        for (int i = 0; i < headers.Length; i++)
        {
            string header = headers[i];
            string value = values[i];

            Vector2 headerSize = font.MeasureString(header);
            Vector2 valueSize = font.MeasureString(value);

            float headerX = currentX + (headerSize.X / 2);
            float valueX = headerX - (valueSize.X / 2);

            spriteBatch.DrawString(font, header, new Vector2(headerX - (headerSize.X / 2), 10), Color.White);
            spriteBatch.DrawString(font, value, new Vector2(valueX, 25), Color.White);

            currentX += headerSize.X + GlobalVariables.HUDBuffer;
        }
    }
}
