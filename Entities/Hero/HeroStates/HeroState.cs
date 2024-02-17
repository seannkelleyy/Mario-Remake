using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Character.HeroStates
{
    public abstract class HeroState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public HeroState()
        {
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite("leftRunMario");
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

    // These will be used for transitions 
    public class StandingLeftState : HeroState
    {
        public StandingLeftState() : base() {
            sprite = spriteFactory.CreateSprite("leftStandMario");
        }
    }

    public class StandingRightState : HeroState
    {
        public StandingRightState() : base()
        {
            sprite = spriteFactory.CreateSprite("rightStandMario");
        }
    }

    public class LeftMovingState : HeroState
    {
        public LeftMovingState() : base() {
            sprite = spriteFactory.CreateSprite("leftRunMario");
        }
    }

    public class RightMovingState : HeroState
    {
        public RightMovingState() : base() {
            sprite = spriteFactory.CreateSprite("rightRunMario");
        }
    }

    public class JumpState : HeroState
    {
        public JumpState() : base() {
            sprite = spriteFactory.CreateSprite("jumpingMario");
        }
    }

    public class CrouchState : HeroState
    {
        public CrouchState() : base() {
            sprite = spriteFactory.CreateSprite("crouchingMario");
        }
    }

    public class CollectState : HeroState
    {
        public CollectState() : base() {
            // add collect sprite
        }
    }

    public class DeadState : HeroState
    {
        public DeadState() : base() {
            // add dead sprite
        }
    }
}
