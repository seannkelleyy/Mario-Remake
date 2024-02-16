using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Character.HeroStates
{
    public abstract class HeroState
    {
        private SpriteBatch _spriteBatch;
        private SpriteFactory _spriteFactory;
        public ISprite _sprite;


        public HeroState(SpriteBatch spriteBatch)
        {
            _spriteFactory = SpriteFactory.Instance;

            _spriteBatch = spriteBatch;
            _sprite = _spriteFactory.CreateSprite("leftRunMario");
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position);
    }

    public class StandingState : HeroState
    {

        public StandingState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class LeftMovingState : HeroState
    {
        public LeftMovingState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class RightMovingState : HeroState
    {
        public RightMovingState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class JumpState : HeroState
    {
        public JumpState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class CrouchState : HeroState
    {
        public CrouchState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class ClollectState : HeroState
    {
        public ClollectState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class PowerUpState : HeroState
    {
        public PowerUpState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class TakeDamageState : HeroState
    {
        public TakeDamageState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class AttackState : HeroState
    {
        public AttackState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }

    public class DeadState : HeroState
    {
        public DeadState(SpriteBatch spriteBatch) : base(spriteBatch) { }

        public override void Update(GameTime gameTime)
        {
            _sprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            _sprite.Draw(spriteBatch, position);
        }
    }
}

