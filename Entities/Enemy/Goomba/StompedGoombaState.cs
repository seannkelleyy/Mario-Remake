using Mario.Entities.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StompedGoombaState : EnemyState
{
    public StompedGoombaState(SpriteBatch spriteBatch) : base(spriteBatch) { }

    public override void Update(GameTime gameTime)
    {
        _sprite.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        _sprite.Draw(spriteBatch, position);
    }
}