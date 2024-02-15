using Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Character.MarioStates
{
    // These classes are an implementationof the state design pattern from from Gang of four book page 305.
    public abstract class MarioState
    {
        protected SpriteBatch SpriteBatch;
        protected ISprite Sprite;


        public MarioState(SpriteBatch spriteBatch, ISprite sprite)
        {
            this.SpriteBatch = spriteBatch;
            this.Sprite = sprite;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(Vector2 position);
    }

    public class StandingState : MarioState
    {
        public StandingState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class LeftMovingState : MarioState
    {
        public LeftMovingState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class RightMovingState : MarioState
    {
        public RightMovingState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class JumpState : MarioState
    {
        public JumpState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class CrouchState : MarioState
    {
        public CrouchState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class ClollectState : MarioState
    {
        public ClollectState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class PowerUpState : MarioState
    {
        public PowerUpState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class TakeDamageState : MarioState
    {
        public TakeDamageState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

        public override void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public override void Draw(Vector2 position)
        {
            Sprite.Draw(SpriteBatch, position);
        }
    }

    public class AttackState : MarioState
    {
        public AttackState(SpriteBatch spriteBatch, ISprite sprite) : base(spriteBatch, sprite) { }

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

