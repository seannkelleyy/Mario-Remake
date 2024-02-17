using Mario.Interfaces;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Enemy.Koopa
{
    public abstract class KoopaState
    {
        protected SpriteFactory spriteFactory;
        public ISprite sprite;

        public KoopaState()
        {
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite("leftKoopa");
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

    public class LeftMovingKoopaState : KoopaState
    {
        public LeftMovingKoopaState() : base() {
            sprite = spriteFactory.CreateSprite("leftKoopa");
        }
    }

    public class RightMovingKoopaState : KoopaState
    {
        public RightMovingKoopaState() : base() {
            sprite = spriteFactory.CreateSprite("rightKoopa");
        }
    }

    public class FlippedKoopaState : KoopaState
    {
        public FlippedKoopaState() : base() {
            sprite = spriteFactory.CreateSprite("flippedKoopa");
        }
    }

    public class StompedKoopaState : KoopaState
    {
        public StompedKoopaState() : base() {
            sprite = spriteFactory.CreateSprite("stompedKoopa");    
        }
    }
}
