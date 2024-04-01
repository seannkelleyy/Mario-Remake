using Mario.Interfaces.Base;
using Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mario.Entities.Abstract
{
	public abstract class AbstractEntityState
	{
        protected SpriteFactory spriteFactory;
        private ISprite sprite;
        protected Hero mario;

        public HeroState(Hero mario)
        {
            this.mario = mario;
            spriteFactory = SpriteFactory.Instance;
            sprite = spriteFactory.CreateSprite((mario.getHorizontalDirection()).ToString() + this.GetType().Name + (mario.currentHealth).ToString());
        }
        public virtual void Jump()
        {
            mario.GetPhysics().Jump();
            mario.currentState = new JumpState(mario);
        }
        public virtual void Crouch()
        {
            if (mario.currentHealth != Hero.health.Mario)
            {
                mario.currentState = new CrouchState(mario);

            }
        }
        public virtual void WalkLeft()
        {
            mario.GetPhysics().WalkLeft();
            mario.currentState = new RunState(mario);
        }
        public virtual void Stand()
        {
            if (mario.GetVelocity().X == 0)
            {
                mario.currentState = new StandState(mario);
            }
        }
        public virtual void WalkRight()
        {
            mario.GetPhysics().WalkRight();
            mario.currentState = new RunState(mario);
        }
        public virtual void PowerUp()
        {

        }
        public virtual void Attack()
        {
            if (mario.currentHealth == Hero.health.FireMario)
            {
                mario.currentState = new AttackState(mario, mario.currentState);
            }
        }
        public virtual void TakeDamage()
        {
            sprite = spriteFactory.CreateSprite((mario.getHorizontalDirection()).ToString() + this.GetType().Name + (mario.currentHealth).ToString());
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

        public Vector2 GetVector()
        {
            return sprite.GetVector();
        }
    }
}

