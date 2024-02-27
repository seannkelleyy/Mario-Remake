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
}
