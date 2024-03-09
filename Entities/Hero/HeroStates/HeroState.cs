using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
            Console.WriteLine(nameof(mario.currentDirection) + this.GetType().Name + nameof(mario.currentHealth));
            sprite = spriteFactory.CreateSprite((mario.currentDirection).ToString() + this.GetType().Name + (mario.currentHealth).ToString());
        }
        public virtual void Jump()
        {
            mario.currentState = new JumpState(mario);
        }
        public virtual void Crouch() {
            if (mario.currentHealth != Hero.health.Mario)
            {
                mario.currentState = new CrouchState(mario);

            }
        }
        public virtual void WalkLeft()
        {
            if (mario.currentDirection == Hero.direction.right)
            {
                mario.currentState = new SlideState(mario);
            }
            else
            {
                mario.currentState = new RunState(mario);
            }
        }
        public virtual void WalkRight()
        {
            if (mario.currentDirection == Hero.direction.left)
            {
                mario.currentState=new SlideState(mario);
            }
            else
            {
                mario.currentState = new RunState(mario);
            }
        }
        public virtual void PowerUp()
        {

        }
        public virtual void TakeDamage()
        {

        }
        public virtual void Die()
        {
            mario.currentState = new DeadState(mario);
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
