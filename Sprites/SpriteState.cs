using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    // These classes are an implementationof the state design pattern from from Gang of four book page 305.
    public abstract class SpriteState
    {
        protected Game1 Game;
        protected SpriteBatch SpriteBatch;
        protected ISprite Sprite;

        public SpriteState(Game1 game, SpriteBatch spriteBatch, ISprite sprite)
        {
            this.Game = game;
            this.SpriteBatch = spriteBatch;
            this.Sprite = sprite;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(Vector2 position);
    }

    public class StillSpriteState : SpriteState
    {
        public StillSpriteState(Game1 game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class MovingStillSpriteState : SpriteState
    {
        public MovingStillSpriteState(Game1 game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class AnimatedSpriteState : SpriteState
    {
        public AnimatedSpriteState(Game1 game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class MovingAnimatedSpriteState : SpriteState
    {
        public MovingAnimatedSpriteState(Game1 game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

}

