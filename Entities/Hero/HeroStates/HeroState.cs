using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace Mario.Entities.Character.HeroStates
{
    public abstract class HeroState
    {
        protected SpriteFactory spriteFactory;
        private ISprite sprite;
        private Hero mario;

        public HeroState(Hero mario)
        {
            this.mario = mario;
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite(nameof(mario.currentDirection)+this.GetType().Name+nameof(mario.currentHealth));
        }
        public virtual void Jump()
        {
            mario.currentState = new JumpState(mario);
        }
        public virtual void WalkLeft()
        {

        }
        public virtual void WalkRight()
        {

        }
        public virtual void TakeDamage()
        {

        }
        public virtual void Die()
        {

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
