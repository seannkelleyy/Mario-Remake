using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mario.Interfaces;

namespace Mario.Sprites
{
    // These classes are an implementationof the state design pattern from from Gang of four book page 305.
    public abstract class SpriteState
    {
        protected MarioRemake Game;
        protected SpriteBatch SpriteBatch;
        protected ISprite Sprite;

        public SpriteState(MarioRemake game, SpriteBatch spriteBatch, ISprite sprite)
        {
            Game = game;
            SpriteBatch = spriteBatch;
            Sprite = sprite;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(Vector2 position);
    }

    public class StillSpriteState : SpriteState
    {
        public StillSpriteState(MarioRemake game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

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
        public MovingStillSpriteState(MarioRemake game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

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
        public AnimatedSpriteState(MarioRemake game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

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
        public MovingAnimatedSpriteState(MarioRemake game, SpriteBatch spriteBatch, ISprite sprite) : base(game, spriteBatch, sprite) { }

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

