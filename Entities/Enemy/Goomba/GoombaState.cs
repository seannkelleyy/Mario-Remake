using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Enemy.Goomba
{
    public abstract class GoombaState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public GoombaState()
        {
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite("goomba");
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

    public class LeftMovingGoombaState : GoombaState
    {
        public LeftMovingGoombaState() : base() { }
    }

    public class RightMovingGoombaState : GoombaState
    {
        public RightMovingGoombaState() : base() { }
    }

    public class FlippedGoombaState : GoombaState
    {
        public FlippedGoombaState() : base() { }
    }

    public class StompedGoombaState : GoombaState
    {
        public StompedGoombaState() : base() { }
    }
}
